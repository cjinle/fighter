using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{

    [SerializeField] Sprite[] nums;
    [SerializeField] SpriteRenderer CurSprite;
    [SerializeField] Sprite blueBg;
    [SerializeField] Sprite greenBg;
    [SerializeField] Sprite redBg;
    [SerializeField] Sprite yellowBg;

    [SerializeField] SpriteRenderer bgRenderer;

    void Awake()
    {
        Debug.Log("card awake");
        //CurSprite.sprite = nums[0];
        //bgRenderer = GetComponent<SpriteRenderer>();
        //bgRenderer.sprite = redBg;
        //GetComponent<SpriteRenderer>().sprite = redBg;
    }

    public void SetBG(string bg)
    {
        Debug.Log("SetBG: " + bg);
        switch (bg)
        {
            case "blue":
                bgRenderer.sprite = blueBg;
                break;
            case "green":
                bgRenderer.sprite = greenBg;
                break;
            case "red":
                bgRenderer.sprite = redBg;
                break;
            case "yellow":
                bgRenderer.sprite = yellowBg;
                break;
        }
    }

    public void SetNum(int num)
    {
        Debug.Log("SetNum: " + num);
        if (num > nums.Length)
        {
            return;
        }
        CurSprite.sprite = nums[num];
    }
}
