using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Transform wayPointL;
    public Transform wayPointR;
    public bool walkR = false;
    float wayPointL_x;
    float wayPointR_x;
    public float moveSpeed = 0.5f;

    private void Start()
    {
        wayPointL_x = wayPointL.transform.position.x;
        wayPointR_x = wayPointR.transform.position.x;

    }
    void Update()
    {
        
        
        float myPos = transform.position.x; 
        
        if(!walkR)
        {
            controller.Move(-moveSpeed, false, false);
            
        }
        else
        {
            controller.Move(moveSpeed, false, false);            
        }
        if(myPos - wayPointL_x <= 3)
        {
            walkR = true;
        }
        else if (wayPointR_x - myPos <= 3)
        {
            walkR = false;
            
        }
    }
}
