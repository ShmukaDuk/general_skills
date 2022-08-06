using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bounce : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject floor;
    private GameObject self;
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject != floor && col.gameObject != self && !col.gameObject.CompareTag("salamiMan"))
        {
            if (col.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                rb = col.gameObject.GetComponent<Rigidbody2D>();
                if (rb.velocity.y * rb.velocity.y >= 0.02)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 40);
                }
            }

        }
    }
}