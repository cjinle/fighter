using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Card : MonoBehaviour
{

    [SerializeField] Sprite[] nums;
    [SerializeField] Sprite[] bgs;
    [SerializeField] SpriteRenderer CurSprite;
    [SerializeField] SpriteRenderer bgRenderer;

    void Awake()
    {
        Debug.Log("card awake");
        //CurSprite.sprite = nums[0];
        //bgRenderer = GetComponent<SpriteRenderer>();
        //bgRenderer.sprite = redBg;
        //GetComponent<SpriteRenderer>().sprite = redBg;
    }

    public void SetNum(int num)
    {
        //transform.DOScaleX(0, 1f).SetEase(Ease.Flash);
        int bgIdx = num >> 4;
        if (bgIdx >= bgs.Length)
        {
            bgIdx %= bgs.Length;
        }
        bgRenderer.sprite = bgs[bgIdx];

        num &= 0x0f;
        if (num >= nums.Length)
        {
            num %= nums.Length;
        }
        CurSprite.sprite = nums[num];
        //transform.DOScaleX(1, 1f).SetEase(Ease.Flash);
        //transform.DOScaleX(1, 1f);
        //Debug.Log("SetBG: " + bgIdx + ", SetNum: " + num);
    }

    public void Dump()
    {
        CurSprite.transform.DOMoveY(2f, 1f);
    }

}
