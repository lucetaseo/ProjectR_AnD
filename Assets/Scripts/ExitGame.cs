using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    private Button exitBtn;
    
    public static void ExitGame()
    {

    }

    // Update is called once per frame
    void Update()
    {
        exitBtn = GetCompoent<Button>();
        //if(exitBtn != null)
        //    exitBtn.onclick.()

    }
}
