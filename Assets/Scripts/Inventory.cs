using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class Inventory {

    public static void InventoryUpdate(List<Gear> gears,Dictionary<GameObject,Gear> dic)
    {
        if (gears.Count != 0)
        {
            for (int i = 0; i < gears.Count; i++)
            {
                //find the key at index i. then apply the key with value localgear at index [i]
                var dickey = dic.ElementAt(i).Key;
                dic[dickey] = gears[i];
                //use ElementAt() reqite system.linq namingspace
                dickey.GetComponent<Image>().sprite = gears[i].icon;
            }
        }
    }

    public static void InventoryConsume<t>(Dictionary<GameObject, Gear> dic,GameObject targetSlotGO,bool isEmpty /*if that gear slot is empty*/,t hs) where t:HeroStatus
    {
        if (isEmpty)
        {
            //
            if (dic.ContainsKey(targetSlotGO)&& dic[targetSlotGO]!=null)
            {
                //let replace player equiped gear with target gear
                #region testgearswitch
                try
                {
                    //hs.Char.ApplyEquipment(dic[targetSlotGO],hs.Char.Head);
                    hs.Char.ApplyEquipment(dic[targetSlotGO]);
                    //hs.Char.Head = dic[targetSlotGO];
                }
                catch(System.Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                }

                #endregion
            }
            else { Debug.Log("the item is not here test"); }
        }
    }

    
}
