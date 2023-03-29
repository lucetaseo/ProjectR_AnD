using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescToggle : MonoBehaviour
{
    public Transform desc;
    [SerializeField]
    private Button openDescBtn;
    [SerializeField]
    private Button closeDescBtn;
    private bool isOpened = false;

    private void ToggleDesc()
    {
        desc.gameObject.SetActive(!isOpened);
    }

    void Start()
    {
        if (openDescBtn == null)
            openDescBtn = GetComponent<Button>();

        if(openDescBtn != null)
            openDescBtn.onClick.AddListener(ToggleDesc);
        if(closeDescBtn != null)
            openDescBtn.onClick.AddListener(ToggleDesc);
    }
}
