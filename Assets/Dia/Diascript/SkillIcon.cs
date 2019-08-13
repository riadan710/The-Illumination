using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIcon : MonoBehaviour
{
    public SpriteRenderer first;
    public SpriteRenderer second;
    public SpriteRenderer third;
    public Sprite[] Iconlist = new Sprite[6];
    public Sprite[] Iconlistsel = new Sprite[6];
    public Shoot data;
    // Start is called before the first frame update
    void Start()
    {
        first.sprite = Iconlist[data.bulletid[0]];
        second.sprite = Iconlist[data.bulletid[1]];
        third.sprite = Iconlist[data.bulletid[2]];
    }

    // Update is called once per frame
    void Update()
    {
        if(data.nowbullet == 0)
            first.sprite = Iconlistsel[data.bulletid[0]];
        else
            first.sprite = Iconlist[data.bulletid[0]];
        if (data.nowbullet == 1)
            second.sprite = Iconlistsel[data.bulletid[1]];
        else
            second.sprite = Iconlist[data.bulletid[1]];
        if (data.nowbullet == 2)
            third.sprite = Iconlistsel[data.bulletid[2]];
        else
            third.sprite = Iconlist[data.bulletid[2]];
    }
}
