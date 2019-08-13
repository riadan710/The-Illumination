using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player;
    public GameObject e_prefab;
    public static ObjectPool pool = new ObjectPool(); // 이거 static임 ㅎㅎ

    private float min_x = 0, max_x = 23.2f;
    private float max_y = 8.0f;

    private float min_res, max_res;
    private int count,cnt;
    private List<int> l;
    private GameManegiment manag;

    private bool end = true;
    void Awake()
    {
        pool.InitPool(e_prefab, 10);
        Player = GameObject.Find("Earth");
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        //StartCoroutine("Spawning_ufo");
    }
    public bool getend()
    {
        return end;
    }
    public void set(int cnt, List<int> colors, float min_res, float max_res)
    {
        this.min_res = min_res;
        this.max_res = max_res;
        count = cnt;
        end = false;
        l = colors;
        StartCoroutine("Spawning_ufo");
    }
    IEnumerator Spawning_ufo()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(min_res,max_res));
            pool.pop().GetComponent<e_Moving>().Spawned(
                l[Random.Range(0, l.Count)],
                new Vector3(Random.Range(min_x, max_x) * 0.5f - 5.8f, max_y, 0),
                Player,
                manag);
            if (++cnt == count)
            {
                end = true;
                StopCoroutine("Spawning_ufo");
            }
        }
    }
}
