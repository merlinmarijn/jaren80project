using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class SaveAndRead : MonoBehaviour
{

    string filename = "marijn";
    string qu = "testq";
    string qu2 = "testq2";
    string qu3 = "testq3";
    string qu4 = "testq4";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void writenow()
    {
        WriteFile(filename, qu, qu2, qu3, qu4);
    }

    [MenuItem("Tools/Write File")]
    public void WriteFile(string FN, string Q, string A1, string A2, string A3)
    {
        if (File.Exists(FN))
        {
            Debug.Log(FN + " already exists");
            return;
        }
        string FileName = FN;
        string test = FN + ".txt";
        string path = "Assets/Resources/" + FileName + ".txt";
        //write some text to the file
        var writer = File.CreateText(FN);
        writer.WriteLine(Q + "," + A1 + "," + A2 + "," + A3);
        writer.Close();
    }
}
