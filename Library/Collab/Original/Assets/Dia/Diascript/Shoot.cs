using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool[] shootch;
    public bool switchdelay;
    bool bulspawnch;
    public float[] shoottimer;
    public int[] bulletid = new int[3];
    public int nowbullet;
    public GameObject[] bullet;
    public GameObject bulletspawn;
    public colorLight cur;
    public int bullettype;
    public GameManegiment manag;

    AudioManager nAudio;
    public string normal;
    public string laser;
    public string bigLaser;
    public string charger;

    // Start is called before the first frame update
    void Start()
    {
        switchdelay = true;
        shoottimer = new float[3];
        nowbullet = 0;
        cur = GameObject.Find("ColorManager").GetComponent<colorLight>();
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
       // nAudio = FindObjectOfType<AudioManager>();
        shootch = new bool[3];
        shootch[0] = true;
        shootch[1] = true;
        shootch[2] = true;
        bulletid[0] = manag.bulletid[0];
        bulletid[1] = manag.bulletid[1];
        bulletid[2] = manag.bulletid[2];
       /* nAudio.SetVolumn(normal, 0.2f);
        nAudio.SetVolumn(laser, 0.2f);
        nAudio.SetVolumn(bigLaser, 0.2f);
        nAudio.SetVolumn(charger, 0.2f);*/
    }

    // Update is called once per        
    void Update()
    {
        if (Input.GetMouseButton(0) && cur.curColor != 0)
        {
            if (bulletid[nowbullet] == 0 && shootch[nowbullet])
            {
                shootch[nowbullet] = false;
                shoottimer[nowbullet] = 0.2f;
                Instantiate(bullet[0], bulletspawn.transform.position, gameObject.transform.rotation);
                nAudio.Play(normal);
                //Debug.Log("asdf");
                StartCoroutine("Shootcheck");
            }
            if (bulletid[nowbullet] == 1 && shootch[nowbullet])
            {
                shootch[nowbullet] = false;
                shoottimer[nowbullet] = 0.5f;
                for (int i = -60; i <= 60; i += 30)
                {
                    Instantiate(bullet[1], bulletspawn.transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z + i));
                    Debug.Log(gameObject.transform.eulerAngles);
                }
                nAudio.Play(normal);
                //Debug.Log("gameObject.transform.eulerAngles.z");
                StartCoroutine("Shootcheck");
            }
            if (bulletid[nowbullet] == 2 && shootch[nowbullet])
            {
                shootch[nowbullet] = false;
                shoottimer[nowbullet] = 3f;
                Instantiate(bullet[2], bulletspawn.transform.position, gameObject.transform.rotation);
                nAudio.Play(charger);
                //Debug.Log("asdf");
                StartCoroutine("Shootcheck");
            }
            if (bulletid[nowbullet] == 3 && !bulspawnch && shootch[nowbullet])
            {
                bulspawnch = true;
                Instantiate(bullet[3], bulletspawn.transform.position, gameObject.transform.rotation);
                nAudio.Play(laser);
            }
            if (bulletid[nowbullet] == 4 && !bulspawnch && shootch[nowbullet])
            {
                shootch[nowbullet] = false;
                shoottimer[nowbullet] = 0.3f;
                Instantiate(bullet[4], new Vector3(gameObject.transform.position.x-0.2f, gameObject.transform.position.y), gameObject.transform.rotation);
                Instantiate(bullet[4], new Vector3(gameObject.transform.position.x+0.2f, gameObject.transform.position.y), gameObject.transform.rotation);
                nAudio.Play(normal);
                //Debug.Log("asdf");
                StartCoroutine("Shootcheck");
            }
            if (bulletid[nowbullet] == 5 && shootch[nowbullet])
            {
                shootch[nowbullet] = false;
                shoottimer[nowbullet] = 5f;
                Instantiate(bullet[5], bulletspawn.transform.position, gameObject.transform.rotation);
                nAudio.Play(bigLaser);
                //Debug.Log("asdf");
                StartCoroutine("Shootcheck");
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            bulspawnch = false;
        }

        if (switchdelay)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && nowbullet != 0)
            {
                bulspawnch = false;
                nowbullet = 0;
                switchdelay = false;
                StartCoroutine("switchdelaych");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && nowbullet != 1)
            {
                bulspawnch = false;
                nowbullet = 1;
                switchdelay = false;
                StartCoroutine("switchdelaych");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && nowbullet != 2)
            {
                bulspawnch = false;
                nowbullet = 2;
                switchdelay = false;
                StartCoroutine("switchdelaych");
            }

        }

    }

    IEnumerator switchdelaych()
    {
        yield return new WaitForSeconds(0.5f);
        switchdelay = true;
    }

    IEnumerator Shootcheck()
    {
        int temp = nowbullet;
        yield return new WaitForSeconds(shoottimer[temp]);
        shootch[temp] = true;
    }

}
