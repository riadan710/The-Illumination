using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthManage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp;
    public Sprite[] earth_state = new Sprite[7];

    void Start()
    {
        hp = 0;
    }

    void Update()
    {
        if(hp == 6)
        {
            SceneManager.LoadScene("Death");
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = earth_state[hp];
    }
    public void hited()
    {
        hp++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        hp++;
    }
}
