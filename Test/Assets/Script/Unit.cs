using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator; // top controll the animatior conditions

    private Vector3 targetPosition; // the goal
   
    private void Update()
    {
        float stoppingDistance = .1f; // the condition to put it so the character stop and not keep moving
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance) // if the distance between the character and the target is largest than the stopping distance then do movement
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized; // direction == target - character  position
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime; // to move the character == the direction * movespeed *  Time.deltaTime
            
            unitAnimator.SetBool("IsWalking", true); // Animation movement condition will be true if we aren't reaching to the stopping distsnce
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false); // Animation movement condition will be false if we are reaching to the stopping distsnce
        }
        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition()); // the target will be the mouse position
        }
       /*
        * before it was going to fixed place , now the new one will go to the the mouse position
        * 
        * if (Input.GetKeyDown(KeyCode.T))
        {
            Move(new Vector3(4, 0, 4));   
        }
       */
    }

    private void Move(Vector3 targetPosition) // to make the  character move , we will make the variable be accsesible so we change it's value in the update
    {
        this.targetPosition = targetPosition; //this is the variable of the class
        // the method will have the location, which is the target , where we want the player go to it
    }

}
