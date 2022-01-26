using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using Lok.Tools;
public class Figher : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject cardPrefab;

    [SerializeField] AudioSource fireAudio;

    GameObject card;

    float m_fireTime = 0;

    bool audioOpen;


    void Start()
    {
        

        
        Debug.Log("init card");
        card = Instantiate(cardPrefab);
        card.transform.position = Vector3.zero;
        ChangeCard();
        //transform.DOMove(Vector3.zero, 1f);
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
        if (Input.GetMouseButtonDown(0))
        {
            ChangeCard();
        }
        //if (Input.GetMouseButton(0))
        //{
        //    var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    pos.z = 0;
        //    //transform.DOMove(pos, .1f);
        //    transform.position = pos;
        //}
        if (Input.touchCount > 0)
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            pos.z = 0;
            transform.position = pos;
            
        }
        m_fireTime += Time.deltaTime;
        if (m_fireTime > .5f)
        {
            Fire();
            //ChangeCard();
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
        tmp.m_speed = 10f;

        if (audioOpen)
        {
            fireAudio.volume = .5f;
            fireAudio.Play();
        }
        
    }

    public void ChangeCard()
    {
        var num = (Random.Range(0, 4) << 4) + Random.Range(1, 10);
        //Debug.Log("ChangeCard: " + num);
        card.SendMessage("SetNum", num);
    }

    public void Zero()
    {
        transform.DOMove(Vector3.zero, 1f);
    }

    public void SetAudio()
    {
        audioOpen = !audioOpen;
    }

}
