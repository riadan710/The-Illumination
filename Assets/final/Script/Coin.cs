using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public SpriteRenderer[] moeny = new SpriteRenderer[4];
    public Sprite[] num = new Sprite[10];
    public GameManegiment manag;

    // Start is called before the first frame update
    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
    }

    // Update is called once per frame
    void Update()
    {
        moeny[0].sprite = num[manag.coin % 10];
        moeny[1].sprite = num[(manag.coin / 10)%10];
        moeny[2].sprite = num[(manag.coin / 100)%10];
        moeny[3].sprite = num[(manag.coin / 1000)%10];

    }
}
