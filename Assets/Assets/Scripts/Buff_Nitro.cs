using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Nitro : Colect
{
    private float nitro = 10;
    public override void Collide()
    {
        GameManager.Instance.NitroVariation(nitro);
    }
}

