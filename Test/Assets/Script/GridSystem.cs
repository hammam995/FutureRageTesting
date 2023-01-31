using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize; // we use it when we handle the grid into the world convertion

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z) + Vector3.right * .2f, Color.white, 1000);
                // draw a line in the world position , Draws a line between specified start and end points
                // The duration is the time (in seconds) for which the line will be visible after it is first displayed. A duration of zero shows the line for just one frame
                // start and end in right by 2 units
                // to see bunch of small dashes
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int z) // this to convert the grid position to the world position
    {
        return new Vector3(x, 0, z) * cellSize; // before it was the distance is by one unity , with the cellsize we multiplay the distance between the dashes more than one unit depends on the cell size
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

    

}