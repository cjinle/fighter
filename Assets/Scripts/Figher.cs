using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
//using Lok.Tools;
public class Figher : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject cardPrefab;
    public GameObject enemyPrefab;
    public GameObject settingsPrefab;

    int score = 0;

    [SerializeField] Text scoreTxt;
    [SerializeField] AudioSource fireAudio;

    GameObject card;

    float m_fireTime = 0;

    bool audioOpen;


    void Start()
    {

        scoreTxt.text = score.ToString();
        //Application.targetFrameRate = 60;
        //Debug.Log("init card");
        //card = Instantiate(cardPrefab);
        //card.transform.position = Vector3.zero;
        //ChangeCard();
        //transform.DOMove(Vector3.zero, 1f);
        InvokeRepeating("CreateEnemy", .1f, 1f);
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
            //ChangeCard();
            CreateEnemy();
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

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 120, Screen.height - 50, 80, 20), "Settings"))
        {
            Debug.Log("devsettings button click");
            //GameObject.Find("/DevSettings").SetActive(true);
            //Instantiate(GameObject.Find("/DevSettings"));
            var curSettings = FindObjectOfType<DevSettings>();
            if (!curSettings)
            {
                Instantiate(settingsPrefab);
            }
            else
            {
                Destroy(curSettings.gameObject);
            }
        }
        if (GUI.Button(new Rect(Screen.width - 220, Screen.height - 50, 80, 20), "Test2"))
        {
            SceneManager.LoadScene("Test2");
        }
        //if (GUI.Button(new Rect(20, 70, 80, 20), "Move"))
        //{
        //    transform.DOMove(Vector3.zero, 1f);
        //}
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
        tmp.m_fighter = this.gameObject;

        if (audioOpen)
        {
            fireAudio.volume = .5f;
            fireAudio.Play();
        }
        
    }

    void CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.SendMessage("SetType", Random.Range(0, 100));
    }

    public void ChangeCard()
    {
        var num = (Random.Range(0, 4) << 4) + Random.Range(1, 10);
        //Debug.Log("ChangeCard: " + num);
        card.SendMessage("SetNum", num);
    }

    public void IncrScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }

    public void SetAudio()
    {
        audioOpen = !audioOpen;
    }

    public void MoveZero()
    {
        transform.DOMove(Vector3.zero, 1f);
    }

}
