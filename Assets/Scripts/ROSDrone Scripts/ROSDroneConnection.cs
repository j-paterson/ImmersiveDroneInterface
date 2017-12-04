﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridgeLib;
using UnityEditor;
using System.IO;

public class ROSDroneConnection : MonoBehaviour {
    private ROSBridgeWebSocketConnection ros = null;

    void Start()
    {
        Debug.Log("Attempting to create ROS connection");
        ros = new ROSBridgeWebSocketConnection("ws://192.168.0.107", 9090);
        ros.AddSubscriber(typeof(ROSDroneSubscriber));
        ros.AddServiceResponse(typeof(ROSDroneServiceResponse));
        ros.Connect();
    }

    // Extremely important to disconnect from ROS. OTherwise packets continue to flow
    void OnApplicationQuit()
    {
        if (ros != null)
        {
            ros.Disconnect();
        }
    }

    // Update is called once per frame in Unity
    void Update()
    {
        ros.Render();
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            GameObject robot = GameObject.FindWithTag("ROSDrone");
            if (robot == null)
                Debug.Log("Can't find the robot???");
            else
            {
                WriteData(robot);
            }
        }
    }

    [MenuItem("Tools/Write file")]
    static void WriteData(GameObject robot)
    {
        string path = "Assets/Resultss/user_test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(robot.transform.position);
        writer.Close();

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset) Resources.Load("test");

        //Print the text from the file
        Debug.Log(asset.text);
    }
}