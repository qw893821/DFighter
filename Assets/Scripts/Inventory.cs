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

    public static void InventoryConsume<t>(Dictionary<GameObject, Gear> dic,GameObject targetSlotGO/*,bool isEmpty temp remove*/,t hs) where t:HeroStatus
    {
            if (dic.ContainsKey(targetSlotGO)&& dic[targetSlotGO]!=null)
            {
                //let replace player equiped gear with target gear
                #region testgearswitch
                try
                {
                    var localchar= hs.Char;
                    Swap(dic, targetSlotGO, localchar.Inven[localchar.ApplyEquipment(dic[targetSlotGO])]);
                }
                catch(Exception ex)
                {
                    Debug.Log(ex.StackTrace);
                }

                #endregion
            }
            else { Debug.Log("the item is not here test"); }
    }

    public static void Swap(/* input dictionary*/Dictionary<GameObject, Gear> dic,/*input gameobject*/GameObject inputTarget,/*player equiped target*/Gear originalTarget)
    {
        //check if the input value is valid
        if (dic != null&&inputTarget!=null&&originalTarget!=null)
        {
            dic[inputTarget] = originalTarget;
            UIController.IconMatch(inputTarget, originalTarget);
        }
    }

    //some wild code here. need update later
    public static void InitialGear(Dictionary<GameObject, Gear> dic,GameObject player)
    {
        var hs = player.GetComponent<HeroStatus>();
        //var armorTypeCount = Enum.GetNames(typeof(Armor)).Length;
        //var key0 = dic.ElementAt(0).Key;
        //dic[key0] = hs.Char.Head;
        //var key1 = dic.ElementAt(1).Key;
        //dic[key1] = hs.Char.Shoulder;
        //var key2 = dic.ElementAt(2).Key;
        //dic[key2] = hs.Char.Bottom;
        //var key3 = dic.ElementAt(3).Key;
        //dic[key3] = hs.Char.Belt;
        //var key4 = dic.ElementAt(4).Key;
        //dic[key4] = hs.Char.Shoes;
        var key0 = dic.ElementAt(0).Key;
        dic[key0] = hs.Char.Head;
        var key1 = dic.ElementAt(1).Key;
        dic[key1] = hs.Char.Shoulder;
        var key2 = dic.ElementAt(2).Key;
        dic[key2] = hs.Char.Bottom;
        var key3 = dic.ElementAt(3).Key;
        dic[key3] = hs.Char.Belt;
        var key4 = dic.ElementAt(4).Key;
        dic[key4] = hs.Char.Shoes;
        //for(var i = 0; i < armorTypeCount; i++)
        //{
        //    var key = dic.ElementAt(i).Key;
        //    dic[key]=
        //}
        foreach (KeyValuePair<GameObject, Gear> pair in dic.Where(pair => pair.Value != null))
        {
            pair.Key.GetComponent<Image>().sprite = pair.Value.icon;
        }
    }
}
