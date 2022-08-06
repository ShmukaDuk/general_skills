using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalVariables
{
    public static string authToken = "secure";
    public static string serverAddressOline = "http://119.18.6.26:27069/main/";    
    public static string serverAddress = "http://192.168.1.103:8080/main/";
    public static string username = "Deru";
    public static bool online = false;
    public static int ranking = 99;
    public static bool isFightingBoss;

    //non static
    public static float currentScore = 0f;
    public static bool levelComplete = false;

    public static string Username { get => username; set => username = value; }

    public static bool[] progressData = new bool[16];
}
