using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescToggle : MonoBehaviour
{
    public Transform desc;
    [SerializeField]
    private Button descButton;

    private bool isOpened = false;
    public bool isToggle = false;
    public bool value = true;

    private void ToggleDesc()
    {
        if (isToggle)
            desc.gameObject.SetActive(!isOpened);
        else
            desc.gameObject.SetActive(value);
    }

    void Start()
    {
        if (descButton == null)
            descButton = GetComponent<Button>();

        if(descButton != null)
            descButton.onClick.AddListener(ToggleDesc);
    }
}
