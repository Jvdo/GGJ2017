using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    float shake = 0;
    float shakeAmount = 0f;
    float decreaseFactor = 1.0f;

    float timer = 0;
    public float freq = 12;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1 / freq)
        {
            if (shake > 0)
            {
                Vector3 blargh = new Vector3(Random.Range(-1f, 1f), Random.Range(-1, 1), 0);
                blargh *= shakeAmount;
                blargh.z = -10;
                transform.localPosition = blargh;
            }
            timer -= 1 / freq;
        }
        if (shake > 0)
        {
            shakeAmount -= Time.deltaTime * shakeAmount / shake;
            shake -= Time.deltaTime * decreaseFactor;
            decreaseFactor = 1 + shake *2;
        }else
        {
            shakeAmount = 0;
            shake = 0;
        }
    }

    public void SetShake(float time, float intensity)
    {
        shake += time;
        shakeAmount += intensity;
        timer = 1 / freq;
    }
}
