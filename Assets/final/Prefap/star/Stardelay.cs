using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stardelay : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        StartCoroutine("switchdelaych");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator switchdelaych()
    {
        yield return new WaitForSeconds(Random.Range(0f,1f));
        ani.SetBool("delay",true);
    }
}
