using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if we click on the mouse button
        {
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
                selectedUnit = unit; // selected unit will be the object we hit and we use it's Unit script function to move
                return true; // true we have been selected an character and hit it by the ray cast
            }
        }
        return false; // false we didnt hit and choose a character
    }
    
    
}
