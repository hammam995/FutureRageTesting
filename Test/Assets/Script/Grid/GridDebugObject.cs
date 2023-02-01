using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GridDebugObject : MonoBehaviour
{
    
    [SerializeField] private TextMeshPro textMeshPro;

    
    private GridObject gridObject; // it will be sent from the function setgrid from the gryd system

    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }

    private void Update()
    {
        textMeshPro.text = gridObject.ToString(); // to update it Txt
    }


    
    
    
    
}
