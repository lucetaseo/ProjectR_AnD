using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAttack : MonoBehaviour
{
    public float range = 3f;


    private void CollisionCheck(float range, Vector3 targetPoint)
    {
        RaycastHit hit;
        if (Physics.SphereCast(targetPoint, range, Vector3.up, out hit))
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
