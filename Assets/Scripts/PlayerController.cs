using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float stopDelayTime = 0.1f;
    private float stopDelayElapsed = 0f;

    public void ForcedSetPosition(Vector3 positon)
    {
        agent.Warp(positon);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKey(InputManager.Instance.player_MoveKey))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain")))
            {
                agent.isStopped = false;
                agent.SetDestination(hit.point);
            }
        }
        else
        {
            if(agent.isStopped == false)
            {
                if (stopDelayElapsed > stopDelayTime)
                {
                    agent.isStopped = true;
                    stopDelayElapsed = 0f;
                }
                else
                    stopDelayElapsed += Time.deltaTime;
            }
        }
    }
}
