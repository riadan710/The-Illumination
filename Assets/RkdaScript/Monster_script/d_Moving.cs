using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_Moving : MonoBehaviour
{
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
    public Sprite[] double_Sprite = new Sprite[7];
    public GameObject target;
    public int double_color;
    public int hp;
    private int life;
    public GameObject effect;
    float MaxWidth = 10.0f;
    float MaxHeight = 10.0f;
    Layzercolor templayzer;
    Charger tempcharge;
    colorBullet tempbullet;
    bool invi;
    //GameObject rs;

    [Range(0, 2)]
    [Tooltip("0 : 고정 위치, 1 : 실시간 추적, 2 : 일자 추락")]
    public int moving = 2;
    public float speed = 1.75f;
    float rad1 = 0.5f, rad2 = 0.4f; //enemy = rad1, player = rad2
    ObjectPool pool = e_Spawn.pool;
    GameManegiment manag;
    public void Spawned(int doublecolor, Vector3 pos, GameObject target, GameManegiment manag)
    {
        this.target = target;
        this.manag = manag;
        double_color = doublecolor + 1;
        hp = 50; // hp 초기화
        life = 2; // life double의 특성
        invi = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = double_Sprite[doublecolor];
        gameObject.transform.position = pos;
        switch (moving)
        {
            case 0:
                transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
                break;
            case 1:
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
        }
        gameObject.SetActive(true); // 오브젝트 깨우기
    }

    void Update()
    {
        if (moving == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (gameObject.transform.position.y <= -8)
        {
            pool.push(gameObject);
            target.GetComponent<EarthManage>().hited();
        }

        if (target != null)
            collision(rad1, rad2);
        if (hp <= 0)
            death();
    }

    float getAngle(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }

    public void collision(float r1, float r2)
    {
        Vector2 p1 = gameObject.transform.position;
        Vector2 p2 = target.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        if (d < r1 + r2)
        {
            pool.push(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        tempbullet = collision.GetComponent<colorBullet>();
        templayzer = collision.GetComponent<Layzercolor>();
        if (tempbullet != null)
        {
            if (tempbullet.bulletcol == double_color)
            {
                tempcharge = collision.GetComponent<Charger>();
                hp -= tempbullet.bulletdamage;
                if (tempcharge != null)
                {
                    tempcharge.spread();
                }
                Destroy(collision.gameObject);

            }
        }
        else if (templayzer != null)
        {
            if (templayzer.bulletcol == double_color && !invi)
            {
                invi = true;
                StartCoroutine("invitime");
                hp -= templayzer.bulletdamage;
            }
        }
    }
    void death()
    {
        Debug.Log(effect);
        switch (life)
        {
            case 1:
                effect.GetComponent<ParticleSystem>().startColor = new Color(colors[double_color, 0], colors[double_color, 1], colors[double_color, 2]);
                Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                manag.coin += Random.Range(3,6);
                pool.push(gameObject);
                break;
            case 2:
                life--;
                hp = 50;
                int c = Random.Range(0,3);
                gameObject.GetComponent<SpriteRenderer>().sprite = double_Sprite[c];
                double_color = c + 1;
                break;
        }
    }
    IEnumerator invitime()
    {
        yield return new WaitForSeconds(0.01f);
        invi = false;
    }
}
