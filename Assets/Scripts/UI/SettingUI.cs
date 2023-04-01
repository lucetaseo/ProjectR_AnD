using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Transform settingMainDesc;

    private bool canOpenSetting;
    private KeyCode openKey = KeyCode.Escape;

    private void OpenSetting()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenSetting && Input.GetKeyDown(openKey))
            OpenSetting();
    }
}
