using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBossFight : MonoBehaviour
{
    
    public GameObject bossCamera;
    public GameObject Boss;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GlobalVariables.isFightingBoss)
        {
            GlobalVariables.isFightingBoss = true;
            Debug.Log("Started Boss fight");
            bossCamera.GetComponent<Camera>().orthographicSize = 10;
            Boss.SetActive(true);


        }
    }
}
