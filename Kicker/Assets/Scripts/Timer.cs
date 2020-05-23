using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int IntGameTime;
    public float gameTime = 180.0f;
    public TMPro.TextMeshProUGUI TimeCounter;


    void Update()
    {
        gameTime -= Time.deltaTime;
        IntGameTime = System.Convert.ToInt32(gameTime);
        if (gameTime <= 0)
        {
            TimeCounter.SetText("00:00");           
        }
        if (IntGameTime/60 < 10)            
            TimeCounter.SetText(((0).ToString() + (IntGameTime / 60).ToString() + ':' + (IntGameTime % 60).ToString()).ToString());
        if (IntGameTime % 60 < 10)
            TimeCounter.SetText(((IntGameTime / 60).ToString() + ':' + (0).ToString() + (IntGameTime % 60).ToString()).ToString());
        if ((IntGameTime / 60 < 10)&& (IntGameTime % 60 < 10))
            TimeCounter.SetText(((0).ToString() + (IntGameTime / 60).ToString() + ':' + (0).ToString() + (IntGameTime % 60).ToString()).ToString());
    }
}
