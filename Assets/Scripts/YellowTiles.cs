using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class YellowTiles : MonoBehaviour
{
   [SerializeField] private GameObject splash;
   [SerializeField] private float splashDelayTime;

   void OnCollisionEnter(Collision collision)
   {
     if (collision.gameObject.tag=="Ball")
     {
        ContactPoint contactPoint = collision.contacts[0];
        GameObject splashGO = Instantiate(splash,contactPoint.point,Quaternion.identity);
        splashGO.transform.SetParent(gameObject.transform);
        Destroy(splashGO,splashDelayTime);
     }
   }
}
