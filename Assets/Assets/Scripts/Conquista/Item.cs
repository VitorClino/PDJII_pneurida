using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textData;
    [SerializeField] private string _dscTexto;
    [SerializeField] private Button btn;
    
    public void Setup(Sprite sprite, string text, string dscTxt, bool ativado, string data)
    {
        gameObject.SetActive(true);
        _sprite.sprite = sprite;
        _text.text = text;
        _textData.text = data;
        _dscTexto = dscTxt;
        //btn.interactable = ativado;
    }
    public void AtualizarTextoDsc(TMP_Text texto)
    {
        texto.text = _dscTexto;
    }
    public void ColectConquistaInderrubavel()
    {
        GerenciadorDeConquistas.Instance.ConquistaInderrubavel();

    }
    public void CollectConquistaVontadeInabalavel()
    {
        GerenciadorDeConquistas.Instance.ConquistaVontadeInabalavel();

    }
    public void SalvarMagia()
    {
        GerenciadorDeConquistas.Instance.SalvarConquistas();
    }
    
}
