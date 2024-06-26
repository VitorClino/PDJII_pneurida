using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelDeConquista : MonoBehaviour
{
    public List<Sprite> spriteConquistas;
    public List<Item> itensPainel;

    private static PainelDeConquista _instance;
    public static PainelDeConquista Instance
    { 
        get {if (_instance == null)
                Debug.LogError("PainelDeConquista esta null");
            return _instance; 
        } 
    }
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        ResetarPainel();
        AtualizarPainel();
    }
    private void OnEnable()
    {
        AtualizarPainel();
    }


    private void ResetarPainel()
    {
        for (int i = 0; i < itensPainel.Count; i++)
        {
            itensPainel[i].gameObject.SetActive(false);
        }
    }
    
    public void AtualizarPainel()
    {
        List<Conquistas> conquistas = GerenciadorDeConquistas.Instance.conquistas;
        for (int i = 0; i < conquistas.Count; i++)
        {
            Sprite sprite = spriteConquistas[0];
            if (conquistas[i].conquistaAtivada)
                sprite = spriteConquistas[1];

            itensPainel[i].Setup(sprite, conquistas[i].nome, conquistas[i].descConquista, conquistas[i].conquistaAtivada, conquistas[i].data);
            itensPainel[i].gameObject.SetActive(true);
        }
    }

}
