using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAttack : SkillMain
{
    public float range = 3f;
    public Vector3 targetPoint;
    

    private IEnumerator ISkillCheck(Controller attacker, Controller victim)
    {
        yield return null;

        if(CollisionCheck(range, targetPoint))
        {
            float finalDamage = attacker.DamageModify(baseDamage, attackType);

        }

        yield return null;
    }

    public override void SkillCheck(Controller attacker, Controller victim)
    {
        
    }


    private bool CollisionCheck(float range, Vector3 targetPoint)
    {
        RaycastHit hit;
        if (Physics.SphereCast(targetPoint, range, Vector3.up, out hit))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
