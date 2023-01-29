using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// creating rayy from the mouse  
// singlotene acces the static functions and methods that's why we do the variable as setter and getter , because it doesnt acces it when we write the name of the class directly we have to create classe name variable to acces it
public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField] public LayerMask mousePlaneLayerMask; // layer mask variable, it will be shown as choosing list , in the inspector

    private void Awake()
    {
        instance = this; // will be this class , to acces the private variables
        //Debug.Log(mousePlaneLayerMask.value); 
        
    }


    private void Update()
    {
        // transform.position = MouseWorld.GetPosition(); they are the same
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition() // is static so it will belong to the class itself not to any instance , we can accese it from any other class
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray));
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask); // the  variable is privat but with the instance we can put it here
        return raycastHit.point; // it will return vector 3 , point and the location of the mouse where it hit
    }



    /*
        * 
        * before the function GetPosition , these were in the Update function 

       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ray cast from the camera to the mouse
       //Debug.Log(Physics.Raycast(ray)); // we will check if the ray cast hit any physics
      //Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit)); // to check if the ray cast hit object has collider , it will retun true
       Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit , float.MaxValue , mousePlaneLayerMask )); // the same like the above one but here we Added the layer mask to it to be specific to check if the ray cast hit object has collider , it will retun true
       transform.position = raycastHit.point; // to make the sphere or the blown elemnt follow the mouse if it wasinside the area , it's pointing in the world space
  */


}
