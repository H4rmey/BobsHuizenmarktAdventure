using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_progress : MonoBehaviour
{   
    public Image timer_circle;
    public Canvas microgame_ui_progress;
    public Canvas microgame_ui_succes;
    public Canvas microgame_ui_fail;

    public bool microgame_start;
    public bool microgame_end;
    public bool microgame_fail;
    public bool microgame_succes;    
    public float waitTime = 5f;

    void Start()
    {
        microgame_start = false;
        microgame_end = false;
        microgame_fail = false;
        microgame_succes = false;

        microgame_ui_fail.enabled = false;
        microgame_ui_succes.enabled = false;
        microgame_ui_progress.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        microgame_state();
    }

    public void microgame_state()
    {
        if (microgame_start == true)
        {
            microgame_ui_progress.enabled = true;

            if(microgame_fail == true)
            {
                microgame_ui_succes.enabled = false;
                microgame_ui_progress.enabled = false;
                microgame_ui_fail.enabled = true;
                microgame_end = true;
            }

            if(microgame_succes == true)
            {
                microgame_ui_fail.enabled = false;
                microgame_ui_progress.enabled = false;
                microgame_ui_succes.enabled = true;
                microgame_end = true;
            }

            if (timer_circle.fillAmount <= 0f)
            {
                microgame_fail = true;
            }
            else
            {
                timer_circle.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            }
        }
    }
}
