using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> listObj;       //풀 오브젝트들이 들어갈 리스트
    private int cnt = 0;
    //private Transform pool;                 //풀
    private GameObject obj;                 //풀에 오브젝트가 없을 경우를 대비한 비상용 오브젝트
    public int count()
    {
        return cnt - listObj.Count;
    }
    public void InitPool(GameObject obj, int poolSize)  //풀 초기화
    {
        listObj = new List<GameObject>();
        this.obj = obj;
        cnt = poolSize;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(obj) as GameObject;
            push(go);
        }
    }

    //풀에서 오브젝트를 하나 꺼냄
    public GameObject pop()
    {
        if (listObj.Count > 0)
        {
            GameObject obj = listObj[0];
            listObj.RemoveAt(0);
            return obj;
        }
        else
        {   //없을 경우 만들어서 반환
            ++cnt;
            return Instantiate(obj) as GameObject;
        }
    }
    public void push(GameObject obj) //오브젝트 풀에 넣기
    {
        listObj.Add(obj);
        obj.SetActive(false);
    }
}
