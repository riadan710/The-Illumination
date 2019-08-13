using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anggimochi : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject W_manage;
    void Start()
    {
        W_manage.GetComponent<WaveSpawn>().waveStart(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
