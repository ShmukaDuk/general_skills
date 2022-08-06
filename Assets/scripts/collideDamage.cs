using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideDamage : MonoBehaviour
{
    public HealthSystem health;
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("name");
        if (col.gameObject.CompareTag("salamiMan"))
        {
            Debug.Log("taking damage");
            health.TakeDamage(20);
            



        }
    }
}
