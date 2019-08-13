using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layzercolor : MonoBehaviour
{
    [Range(0, 1)]
    [Tooltip("0 : 기본래이저, 1 : 크고아름다운래이저")]
    public int type = 1;
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
        if(type == 0)
        {
            bulletcol = cur.curColor;
            if (bulletcol == 0)
                Destroy(this.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(colors[cur.curColor, 0], colors[cur.curColor, 1], colors[cur.curColor, 2]);
        }
        if (type == 1)
        {
            StartCoroutine(CoFadeOut(0.5f));
        }

    }
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.color = tempColor;
        Destroy(this.gameObject);
    }
}
