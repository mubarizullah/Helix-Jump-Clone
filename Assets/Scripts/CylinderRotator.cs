using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CylinderRotator : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
   void FixedUpdate()
   {

     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
     {
       Touch touch = Input.GetTouch(0);
       Vector3 TouchRot = touch.deltaPosition;
       transform.Rotate(0f,TouchRot.x * rotSpeed * Time.deltaTime , 0f);
     }
   }

   
}
