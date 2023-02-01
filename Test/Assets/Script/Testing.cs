using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // we moved all the code to the LevelGrid Script

    private void Start()
    {
        

       // Debug.Log(new GridPosition(5, 7)); // it will debug this from the begenning when we start
    }

    private void Update()
    {
       // Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition())); // we will debug the gridposition when we put the mouse on it, this the seccond function
    }

}
