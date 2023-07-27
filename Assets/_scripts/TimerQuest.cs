using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerQuest : MonoBehaviour
{
    public Slider timerSlider;
    bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (isStop == false)
        {
            if (timerSlider.value > timerSlider.minValue)
            {
                timerSlider.value -= Time.deltaTime;
            }
            else
            {
                isStop = true;
                Debug.Log("Stop");
            }

        }
    }
}
