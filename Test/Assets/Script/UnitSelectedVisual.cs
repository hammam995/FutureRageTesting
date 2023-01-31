using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    

    
    
    
    
    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual(); // we will update it in the start , because before it was only updated when we select the character , now we are updating it from the begenning

    }
    
    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual(); // we will update it when we change the selection
       
    }



    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit) // we compare if it was this Unit ,if so so we weant to show this visual , because GetSelectedUnit() function method will return the current Unit
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false; // if it wasnt the same Unit then make it false
        }
    }

    
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    

    
}
