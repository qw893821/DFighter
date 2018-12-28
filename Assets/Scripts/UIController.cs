using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController  {

    //need some work to fix this long long argument list
	public static void UIDisplayHandler(bool unshow,GameObject uigo,string uiname,float currentVal,float maxVal,float normalSize)
    {
        if (!unshow)
        {
            uigo.SetActive(true);
            try
            {
                //change the x value of ui
                var targetUI = uigo.transform.Find(uiname);
                var orgVal = targetUI.GetComponent<RectTransform>().sizeDelta;
                targetUI.GetComponent<RectTransform>().sizeDelta = new Vector2(UIResizer(currentVal, maxVal, normalSize), orgVal.y);
                UIResizer(currentVal,maxVal, normalSize);
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

    private static float UIResizer(float currentVal,float maxVal,float normalSize)
    {
        return normalSize*(currentVal / maxVal);
    }

    public static void ActiveUIDisplayerHandler(GameObject uigo,string inputname)
    {
        bool active;
        active = uigo.activeInHierarchy;
        if (Input.GetKeyDown(inputname))
        {
            
            uigo.SetActive(!active);
        }
    }

    public static void Equip(GameObject go,Gear gear)
    {

    }
}
