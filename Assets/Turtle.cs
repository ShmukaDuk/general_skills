using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{    
    public Rigidbody2D rb;
    public int bulletDamage = 20;
    public Animator animator;
    public GameObject impactEffect;

    void Start()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] otherObjects2 = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject obj in otherObjects2)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        GameObject[] otherObjects3 = GameObject.FindGameObjectsWithTag("Turtle");
        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }   
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        
        genericBadie baddieHP = col.GetComponent<genericBadie>();
        if (baddieHP != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            animator.SetBool("hit", true);
            baddieHP.TakeDamage(150);
            Debug.Log("hit Toon with HP system");
            StartCoroutine(ExampleCoroutine());
            //Destroy(gameObject);
        }
        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            animator.SetBool("hit", true);
            boss.TakeDamage(100);
            Debug.Log("hit Toon with HP system");
            StartCoroutine(ExampleCoroutine());
            //Destroy(gameObject);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
    }
    IEnumerator ExampleCoroutine()
    {        
        Debug.Log("Started Coroutine at timestamp : " + Time.time);        
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        

    }





}
