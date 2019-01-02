using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;

public class Inventory {
    //current plan, first 5 element will be default gear, so ignore the first five now
    public static void InventoryAdd(Gear gear,Dictionary<GameObject,Gear> dic)
    {
        //if (gears.Count != 0)
        //{
        //    for (int i = 5; i < gears.Count; i++)
        //    {
        //        //find the key at index i. then apply the key with value localgear at index [i]
        //        var dickey = dic.ElementAt(i).Key;
        //        dic[dickey] = gears[i];
        //        //use ElementAt() reqite system.linq namingspace
        //        dickey.GetComponent<Image>().sprite = gears[i].icon;
        //    }
        //}
        //when input gear is not null, add it to the first null dic element and break
        if (gear!=null)
        {
            for(int i=0;i<dic.Count;i++)
            {
                var dickey = dic.ElementAt(i).Key;
                if (dic[dickey] == null)
                {
                    dic[dickey] = gear;
                    dickey.GetComponent<Image>().sprite = gear.icon;
                    break;
                }
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
                    //hs.Char.ApplyEquipment(dic[targetSlotGO]);
                    //hs.Char.Head = dic[targetSlotGO];
                    var localchar= hs.Char;
                    Swap(dic, targetSlotGO, localchar.Inventory[localchar.ApplyEquipment(dic[targetSlotGO])]);
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

    public static void Swap(/* input dictionary*/Dictionary<GameObject, Gear> dic,/*input gameobject*/GameObject inputTarget,/*player equiped target*/Gear originalTarget)
    {
        //check if the input value is invalid
        if (dic != null&&inputTarget!=null&&originalTarget!=null)
        {
            //GameObject key=null;
            //foreach(KeyValuePair<GameObject,Gear> pair in dic)
            //{
            //    if (pair.Value == inputTarget)
            //    {
            //        key = pair.Key;
            //        break;
            //    }
            //}
            //if (key != null)
            //{
            //    dic[key] = originalTarget;
            //}
            dic[inputTarget] = originalTarget;
            inputTarget.GetComponent<Image>().sprite = originalTarget.icon;
        }
    }
}
