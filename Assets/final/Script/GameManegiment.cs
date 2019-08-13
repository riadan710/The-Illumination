using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegiment : MonoBehaviour
{
    public bool musicon = true;
    public bool shootingtype = true;//true 스위치, false 버튼
    public int[] bulletlv = new int[6];
    public int[] bulletid = new int[3];
    public int nownum;
    public int coin;
    public int wave = 1;

    void Start()
    {
        Screen.SetResolution(1200, 900, false);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
