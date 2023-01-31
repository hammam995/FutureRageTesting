using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    
    public static UnitActionSystem Instance { get; private set; } // propority , 
    
    public event EventHandler OnSelectedUnitChanged;
    
    
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    private void Awake()
    {
        if (Instance != null) // to make sure that we only have one from this script , objectg
        {
            Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return; // return so we dont set the instance again
        }
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if we click on the mouse button
        {
            // in the first time we will select the character will not move , but after wee select it we can move it , before it was select and moving in same time
            if (TryHandleUnitSelection()) return; // if it's true we breake and go out , by not continue to the next lines , we exit from the conditions of the mouse button
            selectedUnit.Move(MouseWorld.GetPosition());
            // the target will be the mouse position
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit)) // if the ray cast hit an object has Unit componnent , make the selected unit == to that unit we selected by the mouse
            {
                
                SetSelectedUnit(unit); 

                // before it was this line is the same but we did it as setter and getter
               //  selectedUnit = unit; // selected unit will be the object we hit and we use it's Unit script function to move
                return true; // true we have been selected an character and hit it by the ray cast
            }
        }
        return false; // false we didnt hit and choose a character
    }
    
    private void SetSelectedUnit(Unit unit) // we are doing it as proprity , setter and getter
    {
        selectedUnit = unit; // to fire the event
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty); // when we change or select the Unit we want this event to happen

    }
    
    public Unit GetSelectedUnit() // to have the refrence
    {
        return selectedUnit;
    }


    
    
    
    
    
}
