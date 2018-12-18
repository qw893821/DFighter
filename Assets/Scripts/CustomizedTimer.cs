using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedTimer
{

    //button trigger use passive and the count is incremental
	public static void ButtonTrigger(string buttonName, ref bool input,ref float timer,float time)
    {
        if (Input.GetButtonDown(buttonName))
        {
            input = true;
        }
        else if (Input.GetButtonUp(buttonName))
        {
            input = false;
        }
        if (input)
        {
            if (timer < time)
            {
                timer += Time.deltaTime;
            }
            else
            {
                input = false;
                timer = 0;
            }
        }
        else { timer = 0; }
    }
    //auto trigger count is decremental
    public static void AutoTrigger(ref bool input, ref float timer,float resetTimer, float endtime = 0/*typically, this value shoud be 0*/)
    {
        if (!input && timer > endtime)
        {
            //countdown
            timer -= Time.deltaTime;
        }
        else {
            timer = resetTimer;
            input = true;
        }

    }
}
