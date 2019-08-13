using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blank : MonoBehaviour
{
    SpriteRenderer spriteren;
    bool temp = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteren = GetComponent<SpriteRenderer>();
        StartCoroutine("Spriteblank");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spriteblank()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            spriteren.enabled = temp;
            temp = !temp;
        }   
    }
}
