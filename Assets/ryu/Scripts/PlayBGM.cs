using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    BGMManager bgm;
    int wave;
    WaveStarter waves;

    private void Awake()
    {
        bgm = FindObjectOfType<BGMManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waves = GameObject.Find("WaveStarter").GetComponent<WaveStarter>();
        wave = waves.manag.wave;
        bgm.SetVolumn(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        BGM();
    }

    void BGM()
    {
        if (wave == 1 || wave == 5 || wave == 9)
        {
            bgm.Stop();
            bgm.Play(3);
            StartCoroutine(DelayFadeInOutCoroutine());
        }
        else if (wave == 2 || wave == 6)
        {
            bgm.Stop();
            bgm.Play(2);
            StartCoroutine(DelayFadeInOutCoroutine());
        }
        else if (wave == 3 || wave == 7)
        {
            bgm.Stop();
            bgm.Play(1);
            StartCoroutine(DelayFadeInOutCoroutine());
        }
        else if (wave == 4 || wave == 8)
        {
            bgm.Stop();
            bgm.Play(0);
            StartCoroutine(DelayFadeInOutCoroutine());
        }
        else if (wave == 10)
        {
            bgm.Stop();
            bgm.Play(Random.Range(0, 4));
            StartCoroutine(DelayFadeInOutCoroutine());
        }
    }

    IEnumerator DelayFadeInOutCoroutine()
    {
        bgm.FadeOutMusic();
        yield return new WaitForSeconds(1.5f);
        bgm.FadeInMusic();
    }
}
