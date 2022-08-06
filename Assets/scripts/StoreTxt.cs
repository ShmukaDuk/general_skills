using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class StoreTxt : MonoBehaviour
{
   

    public static void WriteUser(string text)
    {
        string path = Application.persistentDataPath + "/user.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(text);
        writer.Close();
        StreamReader reader = new StreamReader(path);        
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    public static void ReadString()
    {
        string path = Application.persistentDataPath + "/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}

