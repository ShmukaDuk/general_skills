using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ovenCollision : MonoBehaviour
{
    public GameObject player;
    public HealthSystem healthSystem;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == player)
        {
            healthSystem.TakeDamage(50);
        }
    }

}
