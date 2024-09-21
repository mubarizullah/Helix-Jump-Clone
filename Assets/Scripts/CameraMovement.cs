using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   private BallBehaviour ball;
   [SerializeField] private Vector3 offset;
   [SerializeField] private float positionOffset;

   void Awake()
   {
    ball = FindAnyObjectByType<BallBehaviour>();
   }

   void LateUpdate()
   {
    if (ball != null)
    {
        Vector3 TargetPos = ball.transform.position  + offset;
        if (ball.transform.position.y<transform.position.y + positionOffset)
        {
            transform.position = TargetPos;
        }
    }
   }
}
