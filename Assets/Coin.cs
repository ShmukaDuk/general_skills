using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int HPRestore = 20;    
    public GameObject impactEffect;
    public GameObject impactEffect2;
    public GameObject clockObject;

    void Start()
    {
        if (clockObject == null)
            clockObject = GameObject.FindGameObjectWithTag("Clock");

    }    
        public void OnTriggerEnter2D(Collider2D col)
    {
        HealthSystem chefHP = col.GetComponent<HealthSystem>();
        if (chefHP)
        {
            if (chefHP.currentHealth >= 99)
            {
                Clock clockScript = clockObject.GetComponent<Clock>();
                clockScript.eatPasta();
                
                
                Instantiate(impactEffect2, transform.position, transform.rotation);
            }
                
            else
            {
                chefHP.TakeDamage(-HPRestore);
                Instantiate(impactEffect, transform.position, transform.rotation);
            }

            SoundManager.PlaySound("omNom");
            Destroy(gameObject);
            

        }
       


    }
}
