using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform head;
    public GameObject player;    
    public Squish squish;
    public Transform playerFoot; 

    private float playerHeight = 0f;
    

    private Rigidbody2D rb;
    public float tune= 0f;
    public Vector2 hitForceV;
    public Vector2 hitForceVN;
    void OnCollisionEnter2D(Collision2D col)
    {
        playerHeight = player.transform.position.y;
        if (playerFoot.transform.position.y > head.transform.position.y)
        {            
            Boing(col);
        }
        else
        {
            if (col.gameObject == player)
            {
                HealthSystem hs = col.gameObject.GetComponent<HealthSystem>();                
                hs.TakeDamage(50);

                Rigidbody2D chefRB = col.gameObject.GetComponent<Rigidbody2D>();
                if (transform.position.x < chefRB.position.x)
                {

                    chefRB.velocity = hitForceV;
                }
                else
                {

                    chefRB.velocity = hitForceVN;
                }
            }
                
        }
    }
    private void Boing(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                rb = col.gameObject.GetComponent<Rigidbody2D>();
                if (rb.velocity.y * rb.velocity.y >= 0.0002f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 20);
                    squish.Squash();

                }
            }

        }
    }
    




}
