using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//         Problemas:
// - ajustar speed do player(da direita esquerda)
// - pontos lembra de usar um json para salvar os pontos
// - UI
// - Sistema de derrota

public class GameManager : MonoBehaviour
{
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

    private static int points =0;
    public int GetPoints { get { return points; } }
    public void Awake()
    {
        Time.timeScale = 0;
        _instance = this;
        currentNitro = 30;
        speed = .7f;
        speedVariation = 0.03f;
    }
    private void Start()
    {
        InvokeRepeating("AddPoints", 0f, 0.5f);
        InvokeRepeating("AddSpeed", 0f, 1f);
    }
    private void AddPoints()
    {
        if (speed < 1)
            points++;
        else
            points += 3;
        if(points%100 == 0)
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
        if(currentNitro+ v <= nitroMax)
            currentNitro += v;
    }
    public void AtivaNitro()
    {
        
        if (currentNitro >= 30)
        {
            Debug.Log("nitro ativo");
            SpeedVariate(buffNitroSpeed);
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
        speed += a;
    }
    private IEnumerator DesligaNitro(float t)
    {
        Debug.Log($"Esperando {t} segundos");
        yield return new WaitForSeconds(t); 
        SpeedVariate(-buffNitroSpeed);
        currentNitro = 0;
        Debug.Log("nitro desligado");
    }
}
