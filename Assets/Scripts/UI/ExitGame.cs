using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    private Button exitBtn;
    
    public static void ExitApp()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        exitBtn = GetComponent<Button>();
        if(exitBtn != null)
           exitBtn.onClick.AddListener(ExitApp);

    }
}
