//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using System;

public class dg_simpleCamFollow : MonoBehaviour
{
    public Transform target;
   
    [Range(1f,40f)] public float laziness = 10f;
    public bool lookAtTarget = true;
    public bool takeOffsetFromInitialPos = true;
    public Vector3 generalOffset;
    public Vector3 whereCameraShouldBe;
    bool warningAlreadyShown = false;
    public GameObject player;
    [Range(0f, 10f)] public float safeZone = 2f;


    private void Start() {
        if (takeOffsetFromInitialPos && target != null) generalOffset = transform.position - target.position;
    }
    public void test()
    {

    }

    void Update()
    {
        if (target != null) {

            
            float playerSpeed = player.GetComponent<PlayerMovement>().horizontalMove;


            whereCameraShouldBe = target.position + generalOffset;
            //whereCameraShouldBe = target.position + generalOffset;
            
            if (Math.Abs((target.position.x)) > Math.Abs(transform.position.x) + safeZone)
            {
                
                transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe , 1 / laziness);
            }
            if (target.position.x < transform.position.x - safeZone)
            {
               
                transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, 1 / laziness);
            }
            if (playerSpeed == 0)
            {
               
                transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, 1 / laziness);
            }

            if (lookAtTarget) transform.LookAt(target);
        } else {
            if (!warningAlreadyShown) {
                Debug.Log("Warning: You should specify a target in the simpleCamFollow script.", gameObject);
                warningAlreadyShown = true;
            }
        }
    }
}
