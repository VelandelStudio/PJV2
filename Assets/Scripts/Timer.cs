using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float time;
    public float timerInterval = 60f;
    float tick;
    private Explosion boom;

    void Awake ()
    {
        time = (int)Time.time;
        tick = timerInterval;
    }

    void Update ()
    {
        GetComponent<Text> ().text = string.Format ("{0:0}:{1:00}", Mathf.Floor(time/60),time%60);
        time = (int)Time.time;

        if(time == tick)
        {
            tick = time + timerInterval;

            Instantiate(boom, transform.position, transform.rotation);
        }
    }

}

