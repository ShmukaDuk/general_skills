using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamiAI : MonoBehaviour
{
    public salamiMovement controller;
    public float moveSpeed = 0.5f;
    public float viewDistance = 20;
    public bool foundPlayer = false;
    public GameObject player;
    public float player_x = 0;
    public Vector2 salamiSpeed;
    public Rigidbody2D rb;

    //ground
    


    

    void FixedUpdate()
    {

        //Debug.Log("salami ai fixed update");
        //Walk To the left:
        player_x = player.transform.position.x;
        if(player_x >= transform.position.x && player_x - transform.position.x <= viewDistance)
        {
            
            rb.AddForce(salamiSpeed);
         
            
            
            //controller.Move(moveSpeed);
        }
        //Walk To the Right:
        if (player_x <= transform.position.x && transform.position.x - player_x <= viewDistance)
        {
            //controller.Move(-moveSpeed); 
            rb.AddForce(-salamiSpeed);

        }

    }
}
