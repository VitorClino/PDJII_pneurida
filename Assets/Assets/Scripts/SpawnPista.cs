using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pista : MonoBehaviour
{

    public GameObject spawn;
    public GameObject[] spawnObjects;
    public GameObject pista;

    private Transform spawnPos;
    
    public void Awake()
    {
        spawnPos = spawn.transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject aux = Instantiate(GameManager.Instance.RandomTitle(), spawnPos.position, spawnPos.rotation);
            Destroy(aux.gameObject, 13);
            CollectionsCreate(aux.GetComponentInChildren<Pista>());
        }
    }

    public void CollectionsCreate(Pista p)
    {
        
        int rd = Random.Range(0, 3);

        for (int i = 0; i <= rd; i++)
        {
            int rdPos = Random.Range(0, p.spawnObjects.Length);
            Transform a = p.spawnObjects[rdPos].transform;
            GameObject obstacle = GameManager.Instance.RandomObjects();
            GameObject aux = Instantiate(obstacle, obstacle.transform.position, obstacle.transform.rotation); // Vector3.zero
            aux.transform.SetParent(a, false);
        }
    }

    public void FixedUpdate()
    {
        MovePista();
    }

    public void MovePista()
    {
        pista.transform.position += new Vector3(0, 0, -GameManager.Instance.GetSpeed);
    }

}
