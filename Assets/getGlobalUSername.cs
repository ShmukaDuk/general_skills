using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getGlobalUsername : MonoBehaviour
{
    public string username;

    public void getUsername()
    {
        string userName = GlobalVariables.username;
        Debug.Log("username form global: " + userName);
    }

}
