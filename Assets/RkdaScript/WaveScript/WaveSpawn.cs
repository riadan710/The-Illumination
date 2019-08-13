﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour
{
    public int mCnt;
    public GameObject e_manage, m_manage, d_manage, t_manage;
    public bool playing;

    public void waveStart(int wave)
    {
        playing = true;
        mCnt = 0;

        switch (wave)
        {
            case 1:
                e_manage.GetComponent<e_Spawn>().set(10, new List<int> { 0, 1 },2.0f,3.0f);
                break;
            case 2:
                e_manage.GetComponent<e_Spawn>().set(20, new List<int> { 0, 1, 3 }, 2.0f, 3.0f);
                break;
            case 3:
                e_manage.GetComponent<e_Spawn>().set(20, new List<int> { 0, 1, 3 }, 2.0f, 3.0f);
                m_manage.GetComponent<m_Spawn>().set(5, new List<int> { 0, 1, 3 }, 8.0f, 10.0f);
                break;
            case 4:
                e_manage.GetComponent<e_Spawn>().set(20, new List<int> { 2, 4, 5 }, 2.0f, 3.0f);
                break;
            case 5:
                e_manage.GetComponent<e_Spawn>().set(25, new List<int> { 2, 4, 5 }, 2.0f, 3.0f);
                m_manage.GetComponent<m_Spawn>().set(10, new List<int> { 2, 4, 5 }, 5.0f, 6.0f);
                break;
            case 6:
                e_manage.GetComponent<e_Spawn>().set(10, new List<int> { 0, 1, 2, 3, 4, 5 }, 2.0f, 5.0f);
                m_manage.GetComponent<m_Spawn>().set(5, new List<int> { 2, 4, 5 }, 5.0f, 7.0f);
                d_manage.GetComponent<d_Spawn>().set(10, new List<int> { 2, 4, 5 }, 3.0f, 4.0f);
                break;
            case 7:
                e_manage.GetComponent<e_Spawn>().set(20, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 3.0f);
                m_manage.GetComponent<m_Spawn>().set(20, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 3.0f);
                break;
            case 8:
                d_manage.GetComponent<d_Spawn>().set(30, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 3.0f, 4.0f);
                break;
            case 9:
                e_manage.GetComponent<e_Spawn>().set(15, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 7.0f);
                m_manage.GetComponent<m_Spawn>().set(15, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 7.0f);
                d_manage.GetComponent<d_Spawn>().set(15, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 7.0f);
                t_manage.GetComponent<t_Spawn>().set(5, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 10.0f, 15.0f);
                break;
            case 10:
                e_manage.GetComponent<e_Spawn>().set(30, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 3.0f);
                m_manage.GetComponent<m_Spawn>().set(15, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 7.0f);
                d_manage.GetComponent<d_Spawn>().set(15, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 2.0f, 7.0f);
                t_manage.GetComponent<t_Spawn>().set(10, new List<int> { 0, 1, 2, 3, 4, 5, 6 }, 7.5f, 10.0f);
                break;
            default:
                playing = false;
                break;
        }
    }

    private void Update()
    {
        if (!playing) return;
        if (e_Spawn.pool.count() + m_Spawn.pool.count() + d_Spawn.pool.count() + t_Spawn.pool.count() == 0)
        {
            if (e_manage.GetComponent<e_Spawn>().getend() &&
                m_manage.GetComponent<m_Spawn>().getend() &&
                d_manage.GetComponent<d_Spawn>().getend() &&
                t_manage.GetComponent<t_Spawn>().getend())
            {
                SceneManager.LoadScene("Shop");
            }
        }
    }
}
