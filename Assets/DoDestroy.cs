using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDestroy : MonoBehaviour
{
    public string tagToDestroy;
    void Awake()
    {        
        Destroy(GameObject.FindWithTag(tagToDestroy));
    }
}
