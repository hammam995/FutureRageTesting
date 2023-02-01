using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // from here we create the Grid system in the game since they are not monobehaviour
    // this is what is on the scene inspector
    
    [SerializeField] private Transform gridDebugObjectPrefab; // the prefab , the pbject has inside it the TXT

    private GridSystem gridSystem; //from the GridSystem class

    private void Start()
    {
        gridSystem = new GridSystem(10, 10, 2f); // the grid system we want to create , 
        
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);


        Debug.Log(new GridPosition(5, 7)); // it will debug this from the begenning when we start
    }

    private void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition())); // we will debug the gridposition when we put the mouse on it, this the seccond function
    }

}
