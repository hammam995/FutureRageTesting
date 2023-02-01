using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    
    private GridSystem gridSystem; // to know which grid system created this object
    private GridPosition gridPosition; //  the x and z

    private Unit unit;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) // constructor to have the refrence of the grid system and the grid position
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        // store them
    }
    // we have to create ( Grid Object) this object in each and every GridPosition
    
    public override string ToString() // to use the same one we have in the Grid Position
    {
        return gridPosition.ToString() + "\n" + unit;
    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
    }


    public Unit GetUnit()
    {
        return unit;
    }
    
    
    
}
