using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorLight : MonoBehaviour
{
    // 000 0 Null
    // 001 1 Red
    // 010 2 Green
    // 011 3 Yellow
    // 100 4 Blue
    // 101 5 Pink
    // 110 6 Cyan
    // 111 7 White
    private int[,] colors = new int[8,3]
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
    public int curColor = 0;
    public GameManegiment manag;
    // Update is called once per frame
    private void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
    }
    void Update()
    {
        if (manag.shootingtype) // switch 타입
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                curColor ^= 1 << 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                curColor ^= 1 << 1;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                curColor ^= 1 << 2;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                curColor = 0;
            }
        }
        else // button 타입
        {
            curColor = 0;
            if (Input.GetKey(KeyCode.W))
            {
                curColor |= 1 << 0;
            }
            if (Input.GetKey(KeyCode.E))
            {
                curColor |= 1 << 1;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                curColor |= 1 << 2;
            }
        }
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(colors[curColor, 0], colors[curColor, 1], colors[curColor, 2]);
    }
}
