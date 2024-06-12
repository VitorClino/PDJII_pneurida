using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConfig : MonoBehaviour
{
    [Header("Nitro")]
    public Image nitroBarFill;
    public Slider sliderNitro;

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
    public void Start()
    {
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

}
