using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer curSprite;

    [SerializeField] float speed;

    void Start()
    {
        
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.Translate(-step, 0, 0);

        var sp = Camera.main.WorldToScreenPoint(transform.position);
        if (sp.x < -Screen.width/2)
        {
            Destroy(gameObject);
        }
    }

    public void SetType(int idx)
    {
        if (idx >= sprites.Length)
        {
            idx %= sprites.Length;
        }
        curSprite.sprite = sprites[idx];
        transform.position = new Vector3(8f, Random.Range(-5f, 5f), 12);
        //float maxWidth = Screen.width / 2;
        //float maxHeight = Screen.height / 2;
        //var pos = new Vector3(Random.Range(-maxWidth, maxWidth), Random.Range(-maxHeight, maxHeight), 12);
        //transform.position = Camera.main.ScreenToWorldPoint(pos+Vector3.right);
    }
}
