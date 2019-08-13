using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    public GameObject W_manage;
    public GameManegiment manag;

    public Sprite[] num = new Sprite[10];
    public SpriteRenderer[] day = new SpriteRenderer[2];

    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        W_manage.GetComponent<WaveSpawn>().waveStart(manag.wave);
        day[0].sprite = num[manag.wave % 10];
        day[1].sprite = num[manag.wave / 10];

        manag.wave++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
