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

   
    
}
