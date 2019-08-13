using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorIndicater : MonoBehaviour
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
    public Sprite[] colors = new Sprite[8];
    void Start()
    {
        cur = GameObject.Find("ColorManager").GetComponent<colorLight>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = colors[cur.curColor];
    }
}
