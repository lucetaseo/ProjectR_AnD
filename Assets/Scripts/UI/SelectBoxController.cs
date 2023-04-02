using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectBoxController : MonoBehaviour
{
    [SerializeField]
    private Button leftBtn;
    [SerializeField]
    private Button rightBtn;
    [SerializeField]
    private TextMeshProUGUI curText;

    public List<string> contents = new List<string>();

    private void GoLeft()
    {
        if (contents.Count == 0)
            return;

        int currentIndex = contents.IndexOf(curText.text);
        int nextIndex = currentIndex - 1;

        if (nextIndex < 0)
        {
            nextIndex = contents.Count - 1;
        }

        curText.text = contents[nextIndex];
    }

    private void GoRight()
    {
        if (contents.Count == 0)
            return;

        int currentIndex = contents.IndexOf(curText.text);
        int nextIndex = currentIndex + 1;

        if (nextIndex >= contents.Count)
        {
            nextIndex = 0;
        }

        curText.text = contents[nextIndex];
    }

    void Start()
    {
        if (leftBtn == null)
            leftBtn = UtillHelper.Find<Button>(transform, "LeftBtn");
        leftBtn.onClick.AddListener(GoLeft);

        if (rightBtn == null)
            rightBtn = UtillHelper.Find<Button>(transform, "RightBtn");
        rightBtn.onClick.AddListener(GoRight);

        if (curText == null)
            curText = UtillHelper.Find<TextMeshProUGUI>(transform, "ValueText");

        if (contents.Count > 0)
        {
            curText.text = contents[0];
        }
    }

}
