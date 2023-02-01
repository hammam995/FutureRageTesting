using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize; // we use it when we handle the grid into the world convertion
    
    private GridObject[,] gridObjectArray; // 2D Array


    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        
        gridObjectArray = new GridObject[width, height]; // before our cycle we identify it , what it's , it will take the x and z


        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(this, gridPosition); // we have to sort them in a good way , so we use 2D Array 
                // new GridObject(this, gridPosition);
                // every 2d index or cell , will do new object , have the grid system , and grid position, gridsystem to know  which grid system it's belong to
                // grid object has been created
                
                
               // Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + Vector3.right * .2f, Color.white, 1000);
                // draw a line in the world position , Draws a line between specified start and end points
                // The duration is the time (in seconds) for which the line will be visible after it is first displayed. A duration of zero shows the line for just one frame
                // start and end in right by 2 units
                // to see bunch of small dashes
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition) // this to convert the grid position to the world position , Berfore it was like this GetWorldPosition(int x, int z)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize; // before it was the distance is by one unity , with the cellsize we multiplay the distance between the dashes more than one unit depends on the cell size
    }

    
    public GridPosition GetGridPosition(Vector3 worldPosition) // from the structer
    {
        
        // we do the opposite of the GetWorldPosition , by reversing it, because here  we want to have the grid position from the world space
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
            
            // Vector3 work with float , so we use Mathf.RoundToInt()
        );
    }

    public void CreateDebugObjects(Transform debugPrefab) // to visualize the indexes , grid objects
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity); // get world position like in the draw line
               // GameObject.Instantiate(debugPrefab, GetWorldPosition(x,z), Quaternion.identity); // is the same but here we aren't store it
               // Game Object and transform are exchangably
               GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
              // gridDebugObject.SetGridObject(gridObjectArray[x,z]); // make it as proper ,getter and setter , to take  the position
              gridDebugObject.SetGridObject(GetGridObject(gridPosition)); //take the position from here
              

            }
        }
        // our prefab will be inistiate in every grid position
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

    
    
    
    
    

}