using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squish : MonoBehaviour
{
    public GameObject self;
    private Vector3 scaleChange;
    private Vector3 vectCheck;   
    

    // Start is called before the first frame update
    public void Squash()
    {
        scaleChange = new Vector3(.10f, -.25f, 0f);
        self.transform.localScale += scaleChange;        
        vectCheck = new Vector3(0.2f, 0.2f, 0.2f);
        if (self.transform.localScale.y < 0F)
        {
            Destroy(self);
        }
    }

}

