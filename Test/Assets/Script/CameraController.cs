using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private void Update()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        // as longest the key hold down
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z =  +1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }
        
        float moveSpeed = 5f;

        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x; // forward to taxe the rotation in the z axis , right to take the rotation with x axis.
        // we add  transform.forward , transform.right , to aligin and connect the rotation with the movment with this we avoid the error when we rotate and when we press the w button it will keep go to the right , with this we are  avoiding it and will keep moving depends on the rotation also
        // without it , it will keep moving depends on the original axis rotation 
        // now the movement will be based on the rotation
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        
        
        Vector3 rotationVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }
        
        float rotationSpeed = 100f;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }
}
