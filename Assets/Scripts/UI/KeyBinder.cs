using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyBinder: MonoBehaviour
{
    [SerializeField]
    private Button keyChangeBtn;
    [SerializeField]
    private Transform key;
    [SerializeField]
    private TextMeshProUGUI keyText;
    [SerializeField]
    private Transform mouse0;
    [SerializeField]
    private Transform mouse1;
    [SerializeField]
    private Transform mouse2;

    public ControlKey myKey = ControlKey.None;
    public KeyCode curKeyCode = KeyCode.None;

    public void ChangeKeyDisplay(KeyCode keyCode)
    {
        mouse0.gameObject.SetActive(false);
        mouse1.gameObject.SetActive(false);
        mouse2.gameObject.SetActive(false);
        key.gameObject.SetActive(false);

        switch (keyCode)
        {
            case KeyCode.Mouse0:
                mouse0.gameObject.SetActive(true);
                break;
            case KeyCode.Mouse1:
                mouse1.gameObject.SetActive(true);
                break;
            case KeyCode.Mouse2:
                mouse2.gameObject.SetActive(true);
                break;
            default:
                {
                    key.gameObject.SetActive(true);
                    string targetString = keyCode.ToString();
                    targetString = targetString.Replace("KeyCode.", "");
                    keyText.text = targetString;
                }
                break;
        }
    }

    private void CallKeyBindController()
    {
        KeyBindController keyBindController = GetComponentInParent<KeyBindController>();
        if (keyBindController != null)
            keyBindController.UpdateKeyInput(myKey);
    }

    // Start is called before the first frame update
    void Init()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();
        foreach (Transform transform in transforms)
            transform.gameObject.SetActive(true);

        if (keyChangeBtn == null)
        {
            keyChangeBtn = GetComponent<Button>();
            keyChangeBtn.onClick.AddListener(CallKeyBindController);
        }
        if (key == null)
            key = transform.Find("Key");
        if (key != null && keyText == null)
            keyText = key.GetComponentInChildren<TextMeshProUGUI>();
        if (mouse0 == null)
            mouse0 = transform.Find("Mouse0");
        if (mouse1 == null)
            mouse1 = transform.Find("Mouse1");
        if (mouse2 == null)
            mouse2 = transform.Find("Mouse2");

        ChangeKeyDisplay(curKeyCode);
    }
}
