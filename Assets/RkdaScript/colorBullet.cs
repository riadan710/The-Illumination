using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorBullet : MonoBehaviour
{
    // 000 0 Null
    // 001 1 Red
    // 010 2 Green
    // 011 3 Yellow
    // 100 4 Blue
    // 101 5 Pink
    // 110 6 Cyan
    // 111 7 White
    private colorLight cur;
    public int bulletcol;
    public int bulletdamage;
    private int[,] colors = new int[8, 3]
    {
        {0,0,0}, // Null
        {255,0,0}, // Red
        {0,255,0}, // Green
        {255,255,0}, // Yellow
        {0,0,255}, // Blue
        {255,0,255}, // Pink
        {0,255,255}, // Cyan
        {255,255,255}  // White
    };
    void Start()
    {
        cur = GameObject.Find("ColorManager").GetComponent<colorLight>();
        bulletcol = cur.curColor;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colors[cur.curColor, 0], colors[cur.curColor, 1], colors[cur.curColor, 2]);

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void changecolor(int bulletcolinput)
    {
        bulletcol = bulletcolinput;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colors[bulletcol, 0], colors[bulletcol, 1], colors[bulletcol, 2]);
    }
}
