using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float delay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoFadeOut(delay));
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime);
    }
    IEnumerator CoFadeOut(float fadeOutTime, System.Action nextEvent = null)
    {
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        Color tempColor = sr.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sr.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }
        sr.color = tempColor;
        Destroy(this.gameObject);
    }
}
