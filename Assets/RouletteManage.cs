using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteManage : MonoBehaviour
{
    public Sprite[] weaponIcons = new Sprite[6];
    public r_rotating[] a = new r_rotating[3];
    private List<int> l = new List<int>();
    public GameManegiment manag;
    private GameObject target;
    public GameObject effect;
    public bool end=true;

    private void Awake()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();

    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && manag.coin >= 30 && end)
        {
            end = false;
            StartCoroutine("endcheck");
            StartCoroutine("moneyminus");

            l.Clear();
            for (int i = 0; i < 6; i++)
            {
                l.Add(i);
            }
            for (int i = 0; i < 3; i++)
            {
                a[i] = gameObject.transform.GetChild(i).GetComponent<r_rotating>();
                int ang = Random.Range(0, 6 - i);
                a[i].num = l[ang];
                //Debug.Log(a[i].num);
                a[i].reroll = 15 + i * 3;
                l.RemoveAt(ang);
            }
        }
        if (Input.GetMouseButtonDown(0) && a[0].end)
        {
            CastRay();
            if(target != null)
            {
                if (target.tag == "slot1" && a[0].onechance)
                {
                    Instantiate(effect, target.transform.position,Quaternion.identity);
                    manag.bulletlv[a[0].num]++;
                    if (manag.bulletlv[a[0].num] > 5)
                        manag.bulletlv[a[0].num] = 5;
                    a[0].onechance = false;
                }
                else if (target.tag == "slot2" && a[0].onechance)
                {
                    Instantiate(effect, target.transform.position, Quaternion.identity);
                    manag.bulletlv[a[1].num]++;
                    if (manag.bulletlv[a[1].num] > 5)
                        manag.bulletlv[a[1].num] = 5;
                    a[0].onechance = false;
                }
                else if (target.tag == "slot3" && a[0].onechance)
                {
                    Instantiate(effect, target.transform.position, Quaternion.identity);
                    manag.bulletlv[a[2].num]++;
                    if (manag.bulletlv[a[2].num] > 5)
                        manag.bulletlv[a[2].num] = 5;
                    a[0].onechance = false;
                }
            }
        }
    }
    void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null)
        { //히트되었다면 여기서 실행
            //Debug.Log (hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
            target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
        }
    }
    IEnumerator endcheck()
    {
        yield return new WaitForSeconds(2f);
        end = true;
    }
    IEnumerator moneyminus()
    {
        yield return new WaitForSeconds(0.1f);
        manag.coin -= 30;
    }
}

