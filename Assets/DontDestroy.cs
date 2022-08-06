using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    
    public string tagToStayAlive = "music";
    // Start is called before the first frame update
    void Awake()
    {
        
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagToStayAlive);
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

   
}
