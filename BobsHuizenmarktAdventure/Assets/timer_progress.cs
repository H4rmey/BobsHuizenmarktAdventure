using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_progress : MonoBehaviour
{   
    public Image timer_circle;
    public bool start_game;
    public bool time_end;
    public float waitTime = 30.0f;

    // Update is called once per frame
    void Update()
    {
        //Reduce fill amount over 30 seconds
        game_time(start_game);
    }

    public void game_time(bool start_game)
    {
        if (start_game == true)
        {
            if(timer_circle.fillAmount <= 0f)
            {
                time_end = true;
            }
            else
            {
                timer_circle.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            }
        }
    }
}
