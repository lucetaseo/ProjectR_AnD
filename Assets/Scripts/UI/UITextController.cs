using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextController : MonoBehaviour
{
    public string keyValue = "";
    public TextMeshProUGUI targetText;

    public void SetLanguageText()
    {
        if (targetText == null)
            return;

        targetText.text = LanguageController.Instance.GetValue(keyValue);
        // 폰트도 변경 필요
    }


    void Start()
    {
        if (targetText == null)
            targetText = GetComponent<TextMeshProUGUI>();
        SetLanguageText();
    }
}
