using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCheck : MonoBehaviour
{
    float healthCount;
    float maxhealthCount = 6f;

    Image ig;

    bool checkSpace;

    // Start is called before the first frame update
    void Start()
    {
        healthCount = 6f;
        checkSpace = false;

        ig = GameObject.Find("OutGame").transform.Find("bg").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            ig.gameObject.SetActive(true);
            checkSpace = true;
        }
        else
        {
            Time.timeScale = 1f;
            ig.gameObject.SetActive(false);
            checkSpace = false;
        }
    }
}
