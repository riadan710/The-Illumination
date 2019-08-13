using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_spawn : MonoBehaviour
{
    public GameObject[] stars = new GameObject[4];
    private float min_x = 0.0f, max_x = 40.0f;
    private float min_y = 0.0f, max_y = 30.0f;
    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            int n = Random.Range(4, 10);
            for(int j = 0; j < n; j++)
            {
                Instantiate(
                    stars[i], 
                    new Vector3((Random.Range(min_x, max_x) * 0.5f) - 10.0f, (Random.Range(min_y, max_y) * 0.5f) - 7.5f,0),
                    Quaternion.EulerRotation(0,0,0));
            }
        }
    }
}
