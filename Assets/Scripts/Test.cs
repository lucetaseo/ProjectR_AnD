using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public MapGenerator mapGenerator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mapGenerator.GenerateMap();
        }
    }
}
