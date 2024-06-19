using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreConfig : MonoBehaviour
{
    public List<GameObject> tires = new List<GameObject>();
    private int pos = 0, lastPos;
    public GameObject panel_unlock;
    private bool tireBloqueado = true;

    public void Awake()
    {
        tires[0].SetActive(true);
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
        tires[lastPos].SetActive(false);

        tires[pos].SetActive(true);
        if (tireBloqueado)
            panel_unlock.SetActive(true);
    }

}
