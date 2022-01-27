using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    Transform bg1;
    Transform bg2;

    float speed = 1f;

    void Start()
    {
        bg1 = GameObject.Find("/bgGroup/bg1").transform;
        bg2 = GameObject.Find("/bgGroup/bg2").transform;
    }

    void Update()
    {
        float dx = speed * Time.deltaTime;
        bg1.Translate(-dx, 0, 0);
        bg2.Translate(-dx, 0, 0);

        if (bg1.position.x <= -20f)
        {
            bg1.Translate(40f, 0, 0);
        }
        if (bg2.position.x <= -20f)
        {
            bg2.Translate(40f, 0, 0);
        }
    }
}
