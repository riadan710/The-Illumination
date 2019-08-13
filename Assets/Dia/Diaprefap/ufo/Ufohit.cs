using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufohit : MonoBehaviour
{
    public int ufocolor;
    public int hp = 100;
    colorBullet tempbullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("fasssadasdasasdasdsfa");
        tempbullet = collision.GetComponent<colorBullet>();
        Debug.Log("fdsfa");
        if (tempbullet.bulletcol == ufocolor)
        {
            Debug.Log("fdssadasfa");
            hp -= tempbullet.bulletdamage;
            Destroy(collision.gameObject);
            if (hp <= 0)
                Destroy(this.gameObject);
        }
    }
}
