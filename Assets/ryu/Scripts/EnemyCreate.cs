using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreate : MonoBehaviour
{
    Text count;
    Text timeCheck;

    float time = 0.0f;
    float gametime = 0.0f;
    int cnt = 0;

    public GameObject prefab;
    public float delta = 1.0f;
    public float MinusDelta = 0.009f;
    public float LimitDelta = 0.22f;

    private GameObject player;

    // Use this for initialization
    void Start()
    {
        count = GameObject.Find("UI").transform.Find("EnemyCount").GetComponent<Text>();
        timeCheck = GameObject.Find("UI").transform.Find("TimeCheck").GetComponent<Text>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // 실시간 시간을 더함.
        time += Time.deltaTime;
        gametime += Time.deltaTime;

        count.text = "Enemy Count : " + cnt.ToString();
        TimeCalculation(time);
        SpawnEnemy();
    }

    void respawnEnemy()
    {
        float MaxWidth = GameObject.Find("Player").transform.position.x;
        float MaxHeight = GameObject.Find("Player").transform.position.y;
        float x = MaxWidth + 8.0f;
        float y = MaxHeight + 23.0f;

        newUnit(Random.Range(0.0f, x * 2) - x, y);
    }

    void newUnit(float x, float y)
    {
        Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    public void IncreaseEnemy() { cnt++; }
    public void DecreaseEnemy() { cnt--; }

    public void SpawnEnemy()
    {
        if (gametime > delta)
        {
            gametime = 0;
            respawnEnemy();
            cnt++;
            delta -= MinusDelta;

            if (delta <= LimitDelta)
            {
                delta = LimitDelta;
            }
        }
    }

    public void TimeCalculation(float _time)
    {
        int sec = (int)_time, min = 0;
        int TimeInterval = sec / 60;

        if (sec % 60 < 60)
        {
            sec = (int)_time % 60;
            _time -= sec;
            min = (int)_time / 60;
        }

        timeCheck.text = "Time : " + min.ToString() + "분 " + sec.ToString() + "초";
    }
}
