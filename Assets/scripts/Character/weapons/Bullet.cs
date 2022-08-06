using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int bulletDamage = 20;
    public GameObject impactEffect;

    public Transform bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] otherObjects2 = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject obj in otherObjects2)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        rb.velocity = transform.right * speed;
        
    }
    public void kill()
    {
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        
        HealthSystem healthSystem = col.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(bulletDamage);
            Debug.Log("hit player with HP system");
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
    

}
