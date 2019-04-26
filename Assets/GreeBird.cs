using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreeBird : Bird
{
    public override void ShowSkill()
    {
        base.ShowSkill();
        Vector3 vector3 = rd.velocity;
        vector3.x *= -1;
        rd.velocity = vector3;
    }

}
