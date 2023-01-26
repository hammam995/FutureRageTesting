using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition; // the goal

    private void Update()
    {
        float stoppingDistance = .1f; // the condition to put it so the character stop and not keep moving
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance) // if the distance between the character and the target is largest than the stopping distance then do
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // direction == target - character  position
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime; // to move the character == the direction * movespeed *  Time.deltaTime
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));
            
        }
    }

    private void Move(Vector3 targetPosition) // to make the  character move , we will make the variable be accsesible so we change it's value in the update
    {
        this.targetPosition = targetPosition; //this is the variable of the class
    }

}
