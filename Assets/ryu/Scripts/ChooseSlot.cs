using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSlot : MonoBehaviour
{
    public GameObject[] slot = new GameObject[3];
    [SerializeField] float time;
    [SerializeField] float offset;

    [SerializeField] float basicSize;
    [SerializeField] float dampTrace;

    Shoot shot;

    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        shot = GameObject.Find("Bulletspawn").GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        vector = Vector3.Lerp(new Vector3(slot[0].transform.localScale.x, slot[0].transform.localScale.y, slot[0].transform.localScale.z),
                new Vector3(basicSize + Mathf.PingPong(Time.time / time, offset), basicSize + Mathf.PingPong(Time.time / time, offset), slot[0].transform.localScale.z), dampTrace);

        switch (shot.nowbullet)
        {
            case 0:
                slot[1].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[2].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[0].transform.localScale = vector;
                break;
            case 1:
                slot[0].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[2].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[1].transform.localScale = vector;
                break;
            case 2:
                slot[0].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[1].transform.localScale = new Vector3(10f, 10f, 0f);
                slot[2].transform.localScale = vector;
                break;
            default:
                break;
        }
    }
}
