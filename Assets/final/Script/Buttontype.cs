using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttontype : MonoBehaviour
{
    GameManegiment manag;
    public bool togle = true;
    public Toggle switchtogle;
    // Start is called before the first frame update
    void Start()
    {
        manag = GameObject.FindGameObjectWithTag("manag").GetComponent<GameManegiment>();
        togle = manag.shootingtype;  
        switchtogle.isOn = togle;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void change()
    {
        togle = switchtogle.isOn;
        manag.shootingtype = togle ;
    }
}
