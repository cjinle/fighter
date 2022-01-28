using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSettings : MonoBehaviour
{
    GameObject plane;
    void Start()
    {
        plane = GameObject.Find("/Plane");
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 120), "Menu");
        if (GUI.Button(new Rect(20, 40, 80, 20), "Audio"))
        {
            Debug.Log("audio button click");
            plane.SendMessage("SetAudio");
        }
        if (GUI.Button(new Rect(20, 70, 80, 20), "Move"))
        {
            plane.SendMessage("MoveZero");
        }

        if (GUI.Button(new Rect(20, 100, 80, 20), "Close"))
        {
            Destroy(gameObject);
        }
    }
}
