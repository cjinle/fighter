using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer curSprite;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void SetType(int idx)
    {
        if (idx > sprites.Length)
        {
            idx %= sprites.Length;
        }
        curSprite.sprite = sprites[idx];
        float maxWidth = Screen.width / 2;
        float maxHeight = Screen.height / 2;
        var pos = new Vector3(Random.Range(-maxWidth, maxWidth), Random.Range(-maxHeight, maxHeight), 12);
        transform.position = Camera.main.ScreenToWorldPoint(pos+Vector3.right);
    }
}
