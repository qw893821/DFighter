using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController  {

	public static void UIDisplayHandler(bool unshow,GameObject uigo)
    {
        if (!unshow)
        {
            uigo.SetActive(true);
            try
            {
                UIResizer();
            }
            catch (System.Exception ex)
            {

                Debug.Log(ex.Message);
                Debug.Log(ex.StackTrace);
            }
        }
        else if (unshow)
        {
            uigo.SetActive(false);
        }
    }

    private static void UIResizer()
    {

    }
}
