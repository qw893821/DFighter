using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="new item",menuName = "Item/GearCollection")]
public class ItemCollection : ScriptableObject {
    public string itemName;
    public Armor armorType;

    [SerializeField]
    private List<Gear> itemList=new List<Gear>();


    //loot a random item from list
    public Gear RandomLoot()
    {
        Debug.Log(itemList.Count);
        var index = Random.Range(0, itemList.Count-1);
        
        Gear gear;
        //when there is no such item, throw an default item
        gear = itemList[0];
        try
        {

            //Gear gear;
            gear = itemList[index];

        }
        catch (System.Exception ex)
        {

            Debug.Log(ex.Message);
        }
        return gear;
    }
	
    
}
