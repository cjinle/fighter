using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Lok.Tools;
public class Figher : MonoBehaviour
{

    public GameObject bulletPrefab;

    float m_fireTime = 0;

    void Start()
    {
        transform.DOMove(Vector3.zero, 1f);
        foreach (int n in Test.GetList(10))
        {
            Debug.Log("Lok.Tools.GetList: "+n);
        }
    }

    void Update()
    {
        var step = 10f * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-step, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(step, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, step, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -step, 0);
        }
        m_fireTime += Time.deltaTime;
        if (m_fireTime > 0.4f)
        {
            Fire();
            m_fireTime = 0;
        }
    }

    void Fire()
    {
        var bullet = Instantiate(bulletPrefab);
        var pos = transform.position;
        pos.x += 1f;
        pos.y -= .2f;
        bullet.transform.position = pos;
        //bullet.SendMessage("SetSpeed", 10f);
        Bullet tmp = bullet.GetComponent<Bullet>();
        tmp.m_speed = 50f;
    }
    
    public void Zero()
    {
        transform.DOMove(Vector3.zero, 1f);
    }

}
