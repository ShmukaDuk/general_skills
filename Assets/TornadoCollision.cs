using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoCollision : MonoBehaviour
{
    public Vector2 pushforce;
    public Vector2 pushforce0;
    public int tornadoDamage = 50;
    public int bossDamage = 20;
    public void OnTriggerEnter2D(Collider2D col)
    {
        genericBadie badGuy = col.GetComponent<genericBadie>();
        if(badGuy)
        {
            badGuy.TakeDamage(tornadoDamage);
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (transform.position.x < rb.position.x)
            {

                rb.velocity = pushforce;
            }
            else
            {

                rb.velocity = pushforce0;
            }
            
        }
        Boss bossman = col.GetComponent<Boss>();
        if (bossman)
        {
            bossman.TakeDamage(bossDamage);
        }

    }
}
