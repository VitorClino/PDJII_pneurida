using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//         Problemas:
// - Sistema de derrota caso saia da area;
// - Sistema de audio
// - Loja

public class GameManager : MonoBehaviour
{
    [Header("General Settings")]

    public List<GameObject> player= new List<GameObject>();
    private int qualPlayer = 0, lastPlayer = 0;
    public int QualPlayer { set { qualPlayer = value; } get { return qualPlayer; } }

    private int coins;
    public List<Informacoes> info;

    private string caminhoSalvar;

    [Header("Move Tittles")]

    private float speed;
    private float speedVariation;
    public GameObject[] titlesList;

    public float GetSpeed
    {
        get { return speed; }
    }

    [Header("Config obstacle and collectibles")]

    public GameObject[] obstacle;
    public GameObject[] buff;
    private float nitroMax = 100;
    private float currentNitro = 0;
    private float buffNitroSpeed = .4f;
    public float GetCurrentNitro { get { return currentNitro; } }

    [Header("Config Player")]

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Controller esta null");
            return _instance;
        }
    }

    private static int points;
    public int GetPoints { get { return points; } }


    public void Awake()
    {
        _instance = this;
        Time.timeScale = 0;
        points = 0;
        currentNitro = 30;
        speed = 1.5f;
        speedVariation = 0.03f;

    }
    private void Start()
    {
        caminhoSalvar = Application.persistentDataPath + "/Informacoes.json";
        CarregarInformacoes();
        coins = info[0].coins;
        player[qualPlayer].gameObject.SetActive(true);

        UIConfig.Instance.AtualizaCoins(info[0].coins);

        InvokeRepeating("AddPoints", 0f, 0.1f);
        InvokeRepeating("AddSpeed", 0f, 1f);
    }

    public void AtualizaPlayer()
    {
        player[lastPlayer].gameObject.SetActive(false);
        player[qualPlayer].gameObject.SetActive(true);
        lastPlayer = qualPlayer;
    }
    public void AddPoints()
    {
        if (speed < 1)
            points++;
        else
            points += 3;
        if (points % 100 == 0)
        {
            NitroVariation(10);
        }
        UIConfig.Instance.AtualizaPontos();
    }
    private void AddSpeed()
    {
        SpeedVariate(speedVariation);
        buffNitroSpeed += speedVariation;
    }

    public GameObject RandomTitle()
    {
        int rd = Random.Range(0, titlesList.Length);
        return titlesList[rd];
    }
    public GameObject RandomObjects()
    {
        int rdObject = Random.Range(0, 10);

        if (rdObject <= 7)
            return RandomObstacle();
        else
            return RandomBuff();
    }
    private GameObject RandomObstacle()
    {
        int rd = Random.Range(0, obstacle.Length);
        return obstacle[rd];
    }
    private GameObject RandomBuff()
    {
        int rd = Random.Range(0, buff.Length);
        return buff[rd];
    }

    public void NitroVariation(float v)
    {
        if (currentNitro + v <= nitroMax)
            currentNitro += v;
    }
    public void AtivaNitro()
    {

        if (currentNitro >= 30)
        {
            Debug.Log("nitro ativo");
            StartCoroutine(DesligaNitro(BuffTime()));
        }

    }
    private float BuffTime()
    {
        float t = 2;
        if (currentNitro >= 30 && currentNitro < 40)
            return t;
        else if (currentNitro >= 40 && currentNitro < 60)
            return t + 1f;
        else if (currentNitro >= 60 && currentNitro < 90)
            return t + 2f;
        else if (currentNitro >= 90)
            return t + 4f;
        else return t;
    }
    public void SpeedVariate(float a)
    {
        if(speed+a > .7)
        speed += a;
    }
    private IEnumerator DesligaNitro(float t)
    {
        Debug.Log($"Esperando {t} segundos");
        SpeedVariate(buffNitroSpeed);
        currentNitro = 0;
        yield return new WaitForSeconds(t);
        SpeedVariate(-buffNitroSpeed);
        Debug.Log("nitro desligado");
    }

    public void Derrota()
    {
        ConferirConquistas();
        GerenciadorDeConquistas.Instance.SalvarConquistas();
        Time.timeScale = 0;
        UIConfig.Instance.derrota.SetActive(true);
    }
    public void ConferirConquistas()
    {
        GerenciadorDeConquistas.Instance.ValidarConquistaInderrubavel();
        GerenciadorDeConquistas.Instance.ValidarConquistaVontadeInabalavel();
    }

    public void AddCoin(int c)
    {
        coins += c;
        UIConfig.Instance.AtualizaCoins(coins);
        SalvaCoins();
        StoreConfig.Instance.ConfereComprar();
        SalvarInformacoes();
    }
    public void DiminuiCoin(int c)
    {
        coins -= c;
        UIConfig.Instance.AtualizaCoins(coins);
        SalvaCoins();
        SalvarInformacoes();
    }
    public void SalvaCoins()
    {
        info[0].coins = coins;
    }

    public void ContaPartidas()
    {
        info[0].partidas++;
        SalvarInformacoes();
    }

    [ContextMenu("Salvar Informacoes")]
    public void SalvarInformacoes()
    {
        string json = JsonHelper.ToJson(info.ToArray());
        File.WriteAllText(caminhoSalvar, json);
    }
    
    [ContextMenu("Carregar informacoes")]
    public void CarregarInformacoes()
    {
        if (File.Exists(caminhoSalvar))
        {
            string jsonSalvo = File.ReadAllText(caminhoSalvar);
            Informacoes[] infoConteiner = JsonHelper.FromJson<Informacoes>(jsonSalvo);

            for (int i = 0; i < infoConteiner.Length; i++)
            {
                info[0].coins = infoConteiner[0].coins;
                info[0].pneuComprado = infoConteiner[0].pneuComprado;
            }
        }
    }
    public void Teste(int i)
    {
        points += i;

        UIConfig.Instance.AtualizaPontos();
    }
}
[System.Serializable]
public class Informacoes
{
    public int coins;
    public List<int> pneuComprado = new List<int>();
    public int partidas;
}