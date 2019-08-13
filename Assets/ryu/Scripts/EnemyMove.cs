using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    GameObject target;
    GameObject rs;

    [Range(0, 1)]
    [Tooltip("0 : 고정 위치, 1 : 실시간 추적, 2 : 일자 추락")]
    public int moving;
    float speed = 3.5f;
    float rad1 = 0.5f, rad2 = 0.4f; //enemy = rad1, player = rad2

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player");
        rs = GameObject.Find("EnemyRespawner");

        //moving = Random.Range(0, 2);

        moving = 2;

        if (moving == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
        }
        else if (moving == 2)
        {
            transform.eulerAngles = new Vector3(0, 0, -180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float MaxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0)).x + 20f;
        float MaxHeight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0)).y + 20f;

        if (moving == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.transform.position.x, target.transform.position.y));
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if ((transform.position.x > MaxWidth || transform.position.x < -MaxWidth) || (transform.position.y > MaxHeight || transform.position.y < -MaxHeight))
        {
            Destroy(this.gameObject);
            rs.GetComponent<EnemyCreate>().DecreaseEnemy();
        }

        if (target != null)
            collision(rad1, rad2);
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
        Vector2 p1 = this.transform.position;
        Vector2 p2 = target.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        if (d < r1 + r2)
        {
            Destroy(this.gameObject);
            Destroy(target);
        }
    }
}
