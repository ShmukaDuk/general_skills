using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{


    

    public void OnTriggerEnter2D(Collider2D col)
    {
        HealthSystem healthSystem = col.GetComponent<HealthSystem>();
        if (healthSystem)
        {
            Debug.Log("dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        

    }

}