using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public GameObject button;
   
    public float cooldown = 5f;
    public float timer = 0f;
    public bool attacking = false;

    // Start is called before the first frame update
    public void onPress()
    {
        attacking = true;        
        button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            if (timer >= cooldown)
            {

                attacking = false ;
                Debug.Log("can press" + timer);
                button.SetActive(true);                
                timer = 0;
            }
            timer += Time.deltaTime;
        }
        
    }
}
