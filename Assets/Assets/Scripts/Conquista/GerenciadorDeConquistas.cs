using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GerenciadorDeConquistas : MonoBehaviour
{
    //private static GerenciadorDeConquistas _instance;
    //public static GerenciadorDeConquistas Instance
    //{ get 
    //    { 
    //        if(_instance == null)
    //        {
    //            Debug.LogError("Gerenciador De Conquistas esta nulo");
    //        }
    //        return _instance;
    //    }
    //}
    //
    //public List<Conquistas> conquistas;
    //string caminhoSalvar;
    //
    //private void Awake()
    //{
    //    _instance = this;
    //
    //}
    //private void Start()
    //{
    //    caminhoSalvar = Application.persistentDataPath + "/conquistas.json";
    //    CarregarConquistas();
    //
    //}
    //public void ConquistaInderrubavel()
    //{
    //    if(ValidarSeConquistaFoiValidada())
    //    {
    //        return;
    //    }
    //    if(GameManager.Instance.GetPoints > 2000)
    //    {
    //        conquistas[0].conquistaAtivada = true;
    //        conquistas[0].nivel = 1;
    //        conquistas[0].descConquista = "Wow! you gave covered 2000 points! now run 4000 to improve the achievement";
    //        GameManager.Instance.AddCoin(conquistas[0].GetRecompensa);
    //        Debug.Log($"A Conquista {conquistas[0].nome} foi destravada!");
    //    }
    //    else if( GameManager.Instance.GetPoints > 4000 && conquistas[0].nivel == 1)
    //    {
    //        conquistas[0].nivel = 2;
    //        conquistas[0].descConquista = "Wow! you gave covered 4000 points! now run 6000 to improve the achievement";
    //        GameManager.Instance.AddCoin(conquistas[0].GetRecompensa);
    //        Debug.Log($"A Conquista {conquistas[0].nome} evoluiu para Silver!!");
    //    }
    //    else if (GameManager.Instance.GetPoints > 6000 && conquistas[0].nivel == 2)
    //    {
    //        conquistas[0].nivel = 3;
    //        conquistas[0].descConquista = "Gold level of achievement reached and as never seen before, the tire is unstoppable";
    //        GameManager.Instance.AddCoin(conquistas[0].GetRecompensa);
    //        Debug.Log($"A Conquista {conquistas[0].nome} evoluiu para Gold!");
    //    }
    //
    //}
    //public bool ValidarSeConquistaFoiValidada()
    //{
    //    bool resultado = false;
    //    for(int i  = 0; i < conquistas.Count; i++)
    //    {
    //        if (conquistas[i].conquistaAtivada  == true)
    //        {
    //            resultado = true;
    //        }
    //    }
    //    return resultado;
    //}
    //
    //
    //[ContextMenu("SalvarConquistas")]
    //public void SalvarConquistas()
    //{
    //    string json = JsonHelper.ToJson(conquistas.ToArray());
    //    File.WriteAllText(caminhoSalvar, json);
    //}
    //
    //[ContextMenu("CarregarConquistas")]
    //public void CarregarConquistas()
    //{
    //    string jsonSalvo = File.ReadAllText(caminhoSalvar);
    //    Conquistas[] conquistasContainer = JsonHelper.FromJson<Conquistas>(jsonSalvo);
    //    for (int i = 0; i < conquistasContainer.Length; i++)
    //    {
    //        conquistas[i].ID = conquistasContainer[i].ID;
    //        conquistas[i].nome = conquistasContainer[i].nome;
    //        conquistas[i].nivel = conquistasContainer[i].nivel;
    //        conquistas[i].data = conquistasContainer[i].data;
    //        conquistas[i].conquistaAtivada = conquistasContainer[i].conquistaAtivada;
    //    }
    //}

//}
//
//[System.Serializable]
//public class Conquistas
//{
//    public int ID;
//    public string nome;
//    public int nivel;
//    public string data;
//    public bool conquistaAtivada;
//    public int codIcone;
//    public string descConquista;
//    public int GetRecompensa
//    {
//        get
//        {
//            return Colect();
//        }
//    }
//        
//    public int Colect()
//    {
//        conquistaAtivada = false;
//        switch (nivel)
//        {
//                case 1:
//                    return 50;
//                    break;
//                case 2:
//                    return 100;
//                    break;
//                case 3:
//                    return 200;
//                    break;
//            
//        }
//        return 0;
//    }
}
