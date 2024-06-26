using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreConfig : MonoBehaviour
{
    public List<Pneu> tires = new List<Pneu>();
    private int pos = 0, lastPos;

    public GameObject panel_unlock;
    public Button btn_comprar;
    public TMP_Text tmp_preco;
    private static StoreConfig _instance;
    public static StoreConfig Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("StoreConfig esta null");
            return _instance;
        }
    }
    private void Start()
    {
        for (int i = 0; i < tires.Count - 1; i++)
        {
            for (int j = 0; j < GameManager.Instance.info[0].pneuComprado.Count; j++)
            {
                if (i == GameManager.Instance.info[0].pneuComprado[j])
                {
                    tires[i].bloquado = false;
                }
            }
        }
    }
    public void Awake()
    {
        _instance = this;
        tires[0].tire.SetActive(true);
        tires[0].selecionado.gameObject.SetActive(true);
    }
    public void Change(int d)
    {
        lastPos = pos;
        if (pos == 0 && d < 0)
            pos = tires.Count-1;
        else if (pos == tires.Count-1 && d > 0)
            pos = 0;
        else
            pos += d;

        Spawn();
        
    }
    public void Spawn()
    {
        tires[lastPos].tire.gameObject.SetActive(false);
        if(tires[lastPos].selecionado != null)
        tires[lastPos].selecionado.gameObject.SetActive(false);

        tires[pos].tire.gameObject.SetActive(true);

        AtualizaHUD();
    }
    private void AtualizaHUD()
    {
        if (tires[pos].bloquado)
        {
            panel_unlock.gameObject.SetActive(true);
            tmp_preco.text = tires[pos].preco.ToString();
        }
        else
        {
            panel_unlock.gameObject.SetActive(false);
            tires[pos].selecionado.gameObject.SetActive(true);
        }
    }
    public void ConfereComprar()
    {
        if (GameManager.Instance.info[0].coins - tires[pos].preco >= 0)
        {
            btn_comprar.interactable = true;
        }
    }
    public void Comprar()
    {
        if (GameManager.Instance.info[0].coins - tires[pos].preco >= 0)
        {
            GameManager.Instance.DiminuiCoin(tires[pos].preco);
            tires[pos].bloquado = false;
            AtualizaHUD();
            GameManager.Instance.info[0].pneuComprado.Add(pos);
            GameManager.Instance.SalvarInformacoes();
        }
    }
    public void Select()
    {
        for (int i = 0; i < tires.Count-1; i++)
        {
            if(i != pos)
            tires[i].selecionado.isOn = false;
        }
        Debug.Log(pos);
        GameManager.Instance.QualPlayer = pos;
    }
    

}
[System.Serializable]
public class Pneu
{
    public GameObject tire;
    public int preco;
    public bool bloquado;
    public Toggle selecionado;

}
