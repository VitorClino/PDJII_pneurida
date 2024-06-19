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

    [Header("Reward Config")]
    public List<TMP_Text> rewardText = new List<TMP_Text>();

    public GameObject[] rewardPanel = new GameObject[2];


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
    public void RestartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void TrocaScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
