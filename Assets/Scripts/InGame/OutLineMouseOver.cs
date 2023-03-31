using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineMouseOver : MonoBehaviour
{
    //[SerializeField]
    //private Renderer targetRenderer;
    private Renderer curOutLinedRenderer;
    public float outLineThickness = 0.03f;

    private void SetOutLine(Renderer renderer, float value)
    {
        if (renderer == null)
            return;

        Renderer tagetRenderer = renderer.GetComponent<Renderer>();
        Material[] materials = tagetRenderer.materials;
        Material outlineMaterial = null;
        foreach (Material material in materials)
        {
            if(material.name.Contains("OutLine"))
            {
                outlineMaterial = material;
                break;
            }
        }

        outlineMaterial.SetFloat("_OutLine_Thickness", value);
        if (value == 0)
            curOutLinedRenderer = null;
    }

    private void MouseOverCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity,1<<LayerMask.NameToLayer("Object")))
        {
            Renderer targetRenderer = hit.transform.GetComponent<Renderer>();
            if (targetRenderer != null)
            {
                if (targetRenderer == curOutLinedRenderer)
                    return;

                SetOutLine(curOutLinedRenderer, 0);
                SetOutLine(targetRenderer, outLineThickness);
                curOutLinedRenderer = targetRenderer;
            }
            else
                SetOutLine(curOutLinedRenderer, 0);
        }
        else
            SetOutLine(curOutLinedRenderer, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        //if (targetRenderer == null)
        //    targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
            return;

        MouseOverCheck();
    }
}
