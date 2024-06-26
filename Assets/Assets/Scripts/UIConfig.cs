using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIConfig : MonoBehaviour
{
    [Header("Nitro")]
    public Image nitroBarFill;
    public Slider sliderNitro;
    private bool isNitro = false;
    public bool IsNitro
    {
        set { IsNitro = value; }
        get { return isNitro; }
    }


    [Header("Geral")]
    public GameObject derrota;
    public List<TMP_Text> txt_coins = new List<TMP_Text>();
    public List<GameObject> UIvida = new List<GameObject>();
    private int vida;


    private static UIConfig _instance;
    public static UIConfig Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UIConfig esta null");
            return _instance;
        }
    }

    [Header("Points Manager")]

    public TMP_Text tx_point;

    public void Awake()
    {
        _instance = this;
        vida = 0;
        for(int i = 0; i < UIvida.Count; i++)
        {
            UIvida[i].gameObject.SetActive(true);
        }
    }
    public void Start() {
        InvokeRepeating("AtualizaSlider", 0f, 0.5f);
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }

    public void AtualizaPontos()
    {
        tx_point.text = GameManager.Instance.GetPoints.ToString();
    }
    public void AtualizaSlider()
    {
            
            sliderNitro.value = GameManager.Instance.GetCurrentNitro;
    }
    public void AtualizaCoins(int c)
    {
        for (int i = 0; i < txt_coins.Count; i++)
        {
            txt_coins[i].text = c.ToString();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Pneurida");
    }
    public void TrocaScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Pausarjogo()
    {
        Time.timeScale = 0;
    }
    public void Despausar()
    {
        Time.timeScale = 1;
    }

    public void AtualizaVidaUI()
    {
        UIvida[vida].gameObject.SetActive(false);
        vida++;
    }
    public void RecuperaVida()
    {
        if (vida != 0)
        {
            vida--;
            UIvida[vida].gameObject.SetActive(true);
        }
    }
}
