using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Cura : Colect
{
    private int cure = 1;

    public int GetBuffCure 
    {
        get { return cure; }
    }
    public override void Collide()
    {
        Player.Instance.Cure(cure);
    }
}
