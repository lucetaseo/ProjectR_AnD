using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData : Singleton<DialogData>
{
    [SerializeField]
    private string indexKey = "Index";
    [SerializeField]
    private string speakerKey = "Speaker";
    [SerializeField]
    private string dialogKey = "Dialog";

    public TextAsset dialogCSV;
    private List<Dictionary<string, string>> dialogDictionary;
    public List<Dictionary<string, string>> DialogDictionary
    {
        get
        {
            if (dialogDictionary == null)
                Init();
            return dialogDictionary;
        }
    }

    public List<string[]> LoadDialog(int index)
    {
        List<string[]> values = new List<string[]>();
        string indexValue = index.ToString();
        
        foreach (var dict in DialogDictionary)
        {
            if (dict.ContainsKey(indexKey) && dict[indexKey] == indexValue)
            {
                string[] pair = new string[2];
                pair[0] = dict[speakerKey];
                pair[1] = dict[dialogKey];
                values.Add(pair);
            }
        }

        return values;
    }

    private void Init()
    {
        if (dialogCSV == null)
            return;

        dialogDictionary = CSVLoader.LoadCSV(dialogCSV);
    }
}
