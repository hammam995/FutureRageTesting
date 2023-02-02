using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
   // the same  thing we did in the Testing Script we will move it here
   
   
   public static LevelGrid Instance { get; private set; } // propority , 

   
   
   // from here we create the Grid system in the game since they are not monobehaviour
   // this is what is on the scene inspector
    
   [SerializeField] private Transform gridDebugObjectPrefab; // the prefab , the pbject has inside it the TXT

   private GridSystem gridSystem; //from the GridSystem class
   
   // one of the main things we will use the Level Grid Script for is to gett and set the Units on each gridPosition
   // when a player go or walk on it we will detect it
   
   public void Awake()
   {
      
      if (Instance != null) // to make sure that we only have one from this script , objectg
      {
         Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
         Destroy(gameObject);
         return; // return so we dont set the instance again
      }
      Instance = this;
      
      
      
      
      gridSystem = new GridSystem(10, 10, 2f); // the grid system we want to create , 
        
      gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
   }
   
   public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
   {
      GridObject gridObject = gridSystem.GetGridObject(gridPosition);
      gridObject.AddUnit(unit);
   }

   public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition, Unit unit)
   {
      GridObject gridObject = gridSystem.GetGridObject(gridPosition);
      return gridObject.GetUnitList();
   }
   public void RemoveUnitAtGridPosition(GridPosition gridPosition ,  Unit unit)
   {
      GridObject gridObject = gridSystem.GetGridObject(gridPosition);
      gridObject.RemoveUnit(unit);
   }

   public GridPosition GetGridPosition(Vector3 worldPosition)
   {

      return gridSystem.GetGridPosition(worldPosition);
      // it's the same if we did this => gridSystem.GetGridPosition(worldPosition);

   }


   public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
   {
      RemoveUnitAtGridPosition(fromGridPosition, unit); // remove this unit from the grid position
      AddUnitAtGridPosition(toGridPosition, unit); // added it to the new grid position
      
   }
   
   
   
   
}
