using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    
    private GridSystem gridSystem; // to know which grid system created this object
    private GridPosition gridPosition; //  the x and z
    private List<Unit> unitList;


    // private Unit unit; // inested of saving one unit we make a list of Units

    public GridObject(GridSystem gridSystem, GridPosition gridPosition) // constructor to have the refrence of the grid system and the grid position
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();

        // store them
    }
    // we have to create ( Grid Object) this object in each and every GridPosition
    
    
    
    /*public override string ToString() // to use the same one we have in the Grid Position
    {
        return gridPosition.ToString() + "\n" + unit;
    }
    */
    
    public override string ToString()
    {
        string unitString = "";
        foreach (Unit unit in unitList)
        {
            unitString += unit + "\n";
        }

        return gridPosition.ToString() + "\n" + unitString;
    }

    
    
    public void AddUnit(Unit unit)
    {
        unitList.Add(unit); // add the unit to the list
    }
    
    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    
    
    
    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    
    
    

    /*  public void SetUnit(Unit unit) 
      {
          this.unit = unit;
      }
  */

    /* public Unit GetUnit()
    {
        return unit;
    }
    */
    
    
}
