using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_rotating : MonoBehaviour
{
    public int reroll;
    public int num;
    public bool end = true;
    public GameManegiment manag;
    public bool onechance = true;

    private RouletteManage ang;
    private Transform a,b;
    private float speed = 20.0f;
    private void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        a = gameObject.transform.GetChild(0); a.transform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);
        b = gameObject.transform.GetChild(1); b.transform.position = gameObject.transform.position + new Vector3(0, 0, 0);
        ang = gameObject.transform.parent.GetComponent<RouletteManage>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && end && manag.coin>=30)
        {

            end = false;
            StartCoroutine("rotating");
        }

    }

    

    IEnumerator rotating()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.001f);
            a.Translate(Vector3.down * speed * Time.deltaTime);
            b.Translate(Vector3.down * speed * Time.deltaTime);
            if (a.position.y <= -1.5f)
            {
                a.Translate(new Vector3(0, 3, 0));
                a.GetComponent<SpriteRenderer>().sprite = ang.weaponIcons[Random.Range(0, 6)];
            }
            if (b.position.y <= -1.5f)
            {
                b.Translate(new Vector3(0, 3, 0));
                if (--reroll == 0)
                {
                    b.GetComponent<SpriteRenderer>().sprite = ang.weaponIcons[num]; 
                    StartCoroutine("stop");
                    StopCoroutine("rotating");
                    yield return 0;
                }
                b.GetComponent<SpriteRenderer>().sprite = ang.weaponIcons[Random.Range(0, 6)];
            }
        }
    }
    IEnumerator stop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.016f);
            a.Translate(Vector3.down * speed * Time.deltaTime);
            b.Translate(Vector3.down * speed * Time.deltaTime);
            if (a.position.y <= -1.5f)
            {
                StopCoroutine("stop");
                a.transform.position = gameObject.transform.position + new Vector3(0, 1.5f, 0);
                b.transform.position = gameObject.transform.position;
                end = true;
                onechance = true;
                yield return 0;
            }
        }
    }
}
