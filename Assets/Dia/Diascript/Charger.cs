using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public GameObject temp;
    public colorBullet me;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<colorBullet>();
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
    }

    public void spread()
    {
        for (int i = 0; i <= 360; i += 45)
        {
            temp = Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(0, 0, i));
            temp.GetComponent<colorBullet>().changecolor(me.bulletcol);
        }
    }

}
