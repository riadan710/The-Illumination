using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkill : MonoBehaviour
{
    private GameObject target;
    public int thisid;
    public GameManegiment manag;
    public SpriteRenderer level;
    public Sprite[] num = new Sprite[6];
    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        level.sprite = num[manag.bulletlv[thisid]];
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            if (target == this.gameObject)
            {
                if (((thisid != manag.bulletid[(manag.nownum + 1) % 3] && thisid != manag.bulletid[(manag.nownum + 2) % 3]) && manag.bulletlv[thisid]>=1) || thisid == 0)
                {
                    manag.bulletid[manag.nownum] = thisid;
                    manag.nownum = 5;
                    Destroy(transform.parent.gameObject);
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
}
