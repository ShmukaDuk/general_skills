using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CameraFollow cameraFollow;
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public float horizontalMove2 = 0f;
    bool jump = false;
    bool crouch = false;
    public Joystick joystick;  
   // float timerL = 0f;
    //float timerR = 0f;
    public Animator animator;
    public void Start()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject obj in otherObjects)
        {
            Debug.Log("Player Found boss");
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }


    public float cameraLag = 6;
    public void jumpButtonPress()
    {
        jump = true;
    }



    public bool left = true;
    void Update()
    {
        horizontalMove2 = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.touchCount >= 0)
        {
            
            horizontalMove = runSpeed * joystick.Horizontal;
            if (joystick.Horizontal >= 0.1f || horizontalMove2 >= 1)
            {                
                animator.SetFloat("speed", runSpeed);
            }
            else if (joystick.Horizontal <= -0.1f || horizontalMove2 <= -1)
            {
                //Debug.Log(horizontalMove2 + " " + joystick.Horizontal);
                animator.SetFloat("speed", runSpeed);
            }
            else
            {
                animator.SetFloat("speed", 0);
                
            }

            if (joystick.Vertical <= -0.8f)
            {
                crouch = true;
            }
            else crouch = false;
            //horizontalMove = joystick.Horizontal * runSpeed;
            //Debug.Log(joystick.Horizontal);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }




        
    }
    void FixedUpdate()
    {
        if (horizontalMove2 != 0)
        {
            controller.Move(horizontalMove2 * Time.fixedDeltaTime, false, jump);
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        jump = false;
    }
    


}
