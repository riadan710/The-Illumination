using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlot : MonoBehaviour
{
    public float speed = 0.5f;
    float targetOffset;

    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetOffset += Time.deltaTime * speed;
        renderer.material.mainTextureOffset = new Vector2(0, targetOffset);
    }
}
