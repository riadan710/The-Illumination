using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameManegiment manag;
    // Start is called before the first frame update
    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
    }

    // Update is called once per frame
    void Update()
    {
        manag.musicon = false;
    }
}
