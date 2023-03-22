using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public DialogController desk;

    // Update is called once per frame
    void Update()
    {
        if (desk == null)
            return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            desk.CallDialog(0);
        }
    }
}
