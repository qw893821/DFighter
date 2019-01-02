using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "new item", menuName = "Item/Gear/Armor")]
public class Gear : ScriptableObject
{
    public string itemName;
    public Armor armorType;
    public Sprite icon;
    public int strength;
    public int inteligence;


    public int GetIndex(List<Gear> gears)
    {
        int index=-1;
        if (gears != null)
        {
            for (int i = 0; i < gears.Count; i++)
            {
                if (gears[i] == this)
                {
                    index = i;
                    break;
                }
            }
        }

        return index;
    }
}
