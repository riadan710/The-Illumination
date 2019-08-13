using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_Moving : MonoBehaviour
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
    public GameObject w_manage;
    public GameObject target;
    public GameObject effect;
    public GameManegiment manag;

    // Start is called before the first frame update
    
    public int m_color;
    public int hp;

    float MaxWidth = 10.0f;
    float MaxHeight = 10.0f;
    colorBullet tempbullet;
    Charger tempcharge;
    Layzercolor templayzer;
    Animator animator;
    bool invi = false;
    //GameObject rs;

    [Range(0, 2)]
    [Tooltip("0 : 고정 위치, 1 : 실시간 추적, 2 : 일자 추락")]
    public int moving = 2;
    public float speed = 3.5f;
    float rad1 = 0.5f, rad2 = 0.4f; //enemy = rad1, player = rad2

    ObjectPool pool = m_Spawn.pool;

    public void Spawned(int color, Vector3 pos, GameObject target, GameManegiment manag)
    {
        this.target = target;
        this.manag = manag;
        hp = 100; // hp 초기화
        m_color = color + 1;
        gameObject.transform.position = pos;
        switch (moving)
        {
            case 0:
                transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y)+180);
                break;
            case 1:
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
        }

        gameObject.SetActive(true); // 오브젝트 깨우기

        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("meteocolor", m_color);
    }

    void Update()
    {
        //float MaxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0)).x + 20f;
        //float MaxHeight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0)).y + 20f;
        if (moving == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y)+180);
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if ((transform.position.x > MaxWidth || transform.position.x < -MaxWidth) || (transform.position.y > MaxHeight || transform.position.y < -MaxHeight))
        {
            pool.push(gameObject);
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
            if (tempbullet.bulletcol == m_color)
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
        else if(templayzer != null)
        {
            if (templayzer.bulletcol == m_color && !invi)
            {
                invi = true;
                StartCoroutine("invitime");
                hp -= templayzer.bulletdamage;;
            }
        }
    }
    void death()
    {
        effect.GetComponent<ParticleSystem>().startColor = new Color(colors[m_color,0], colors[m_color,1], colors[m_color,2]);
        Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        manag.coin += Random.Range(2, 4);
        pool.push(gameObject);
    }
    IEnumerator invitime()
    {
        yield return new WaitForSeconds(0.01f);
        invi = false;
    }
}
