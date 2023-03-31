using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public MapGenerator mapGenerator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mapGenerator.GenerateMap();
            NavMeshSurface nav = FindObjectOfType<NavMeshSurface>();
            nav.BuildNavMesh();
        }
    }
}
