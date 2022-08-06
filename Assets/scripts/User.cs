using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class User
{
    override
     public String ToString()
    {
        return username + " " + highScore;
    }

    public int id;
    public string username;
    //public string password;
    //public string token;
    public string highScore;
    public string highScoreName;

}
[Serializable]
public class UserObject
{
    public User[] users;
}