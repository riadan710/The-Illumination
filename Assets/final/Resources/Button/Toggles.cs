using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggles : MonoBehaviour
{
    private GameObject target;
    public int check=0;
    public bool togle = true;
    Animator ani;
    public GameManegiment manag;
    // Start is called before the first frame update
    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        togle = manag.musicon;
        ani = GetComponent<Animator>();
        ani.SetBool("Trigger", togle);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
            if (target == this.gameObject)
            {
                check = 1;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CastRay();
            if (target == this.gameObject && check == 1)
            {
                togle = !togle;
                ani.SetBool("Trigger", togle);
                manag.musicon = togle;
                
                check = 0;
            }
            else
            {
                check = 0;
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
