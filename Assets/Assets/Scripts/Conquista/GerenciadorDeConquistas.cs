using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GerenciadorDeConquistas : MonoBehaviour
{
    private static GerenciadorDeConquistas _instance;
    public static GerenciadorDeConquistas Instance
    { get 
        { 
            if(_instance == null)
            {
                Debug.LogError("Gerenciador De Conquistas esta nulo");
            }
            return _instance;
        }
    }
    
    public List<Conquistas> conquistas;
    string caminhoSalvar;
    
    private void Awake()
    {
        _instance = this;
    
    }
    private void Start()
    {
        caminhoSalvar = Application.persistentDataPath + "/conquistas.json";
        CarregarConquistas();
    
    }
    public void ConquistaInderrubavel()
    {
        if (conquistas[0].conquistaAtivada)
        {
            switch (conquistas[0].nivel)
            {
                case 0:
                    break;
                case 1:
                    GameManager.Instance.AddCoin(50);
                    conquistas[0].descConquista = "Percorra 4000 pontos para evoluir a conquista";
                    conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                    conquistas[0].conquistaAtivada = false;
                    Debug.Log("Conquista Coletada");
                    break;
                case 2:
                    GameManager.Instance.AddCoin(100); 
                    conquistas[0].nivel = 3;
                    conquistas[0].descConquista = "Percorra 6000 pontos para evoluir a conquista";
                    conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                    conquistas[0].conquistaAtivada = false;
                    Debug.Log("Conquista Coletada");
                    break;
                case 3:
                    GameManager.Instance.AddCoin(200);
                    conquistas[0].nivel = 4;
                    conquistas[0].descConquista = "voce chegou no ultimo nivel da conquista";
                    conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                    conquistas[0].conquistaAtivada = false;
                    Debug.Log("Conquista Coletada");
                    break;
            }
            PainelDeConquista.Instance.AtualizarPainel();
        }
        else { Debug.Log("Conquista nao esta ativa"); }

    }
    public void ValidarConquistaInderrubavel()
    {
        if (GameManager.Instance.GetPoints > 2000 && conquistas[0].nivel == 0)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 1;
        }
        if (GameManager.Instance.GetPoints > 4000 && conquistas[0].nivel == 1)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 2;
        }
        if (GameManager.Instance.GetPoints > 6000 && conquistas[0].nivel == 2)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 3;
        }
    }

    public void ConquistaVontadeInabalavel()
    {
        if (conquistas[1].conquistaAtivada)
        {
            if (GameManager.Instance.info[0].partidas >= 50 && conquistas[1].nivel == 1)
            {
                conquistas[0].descConquista = "play 100 matches to unlock this achievement";
                conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                conquistas[0].conquistaAtivada = false;
                Debug.Log("Conquista Coletada");
            }
            else if (GameManager.Instance.info[0].partidas >= 100 && conquistas[1].nivel == 2)
            {
                conquistas[0].descConquista = "play 200 matches to unlock this achievement";
                conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                conquistas[0].conquistaAtivada = false;
                Debug.Log("Conquista Coletada");
            }
            else if (GameManager.Instance.info[0].partidas >= 150 && conquistas[1].nivel == 3)
            {
                conquistas[0].descConquista = "You have reached the last level of this achievement";
                conquistas[0].data = System.DateTime.Now.ToString(" dd/ MM / yyyy");
                conquistas[0].conquistaAtivada = false;
                Debug.Log("Conquista Coletada");
            }
        }
    }
    public void ValidarConquistaVontadeInabalavel()
    {
        if (GameManager.Instance.info[0].partidas > 50 && conquistas[1].nivel == 0)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 1;
        }
        if (GameManager.Instance.info[0].partidas > 100 && conquistas[1].nivel == 1)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 2;
        }
        if (GameManager.Instance.info[0].partidas > 150 && conquistas[1].nivel == 2)
        {
            conquistas[0].conquistaAtivada = true;
            conquistas[0].nivel = 3;
        }
    }

    [ContextMenu("SalvarConquistas")]
    public void SalvarConquistas()
    {
        string json = JsonHelper.ToJson(conquistas.ToArray());
        File.WriteAllText(caminhoSalvar, json);
    }
    
    [ContextMenu("CarregarConquistas")]
    public void CarregarConquistas()
    {
        if (File.Exists(caminhoSalvar))
        {
            string jsonSalvo = File.ReadAllText(caminhoSalvar);
            Conquistas[] conquistasContainer = JsonHelper.FromJson<Conquistas>(jsonSalvo);
            for (int i = 0; i < conquistasContainer.Length; i++)
            {
                conquistas[i].ID = conquistasContainer[i].ID;
                conquistas[i].nome = conquistasContainer[i].nome;
                conquistas[i].nivel = conquistasContainer[i].nivel;
                conquistas[i].data = conquistasContainer[i].data;
                conquistas[i].conquistaAtivada = conquistasContainer[i].conquistaAtivada;
            }
        }
    }
}

[System.Serializable]
public class Conquistas
{
    public int ID;
    public string nome;
    public int nivel;
    public string data;
    public bool conquistaAtivada = true;
    public bool coletavel = false;
    public int codIcone;
    public string descConquista;
        
    public int Colect()
    {
        conquistaAtivada = false;
        switch (nivel)
        {
            case 1:
                return 50;
                break;
            case 2:
                return 100;
                break;
            case 3:
                return 200;
                break;
            
        }
        return 0;
    }
}
