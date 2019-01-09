using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeController;
[CreateAssetMenu(fileName ="Character",menuName ="Character/Hero")]
public class Hero : Characters {
    
    //set five element as default inventory
    //head, bottom belt shoes and shoulder
    [SerializeField]
    private List<Gear> _inventory;

    [SerializeField]
    private Gear _head;
    [SerializeField]
    private Gear _bottom;
    [SerializeField]
    private Gear _belt;
    [SerializeField]
    private Gear _shoes;
    [SerializeField]
    private Gear _shoulder;


    public Gear Head { get { return _head; }private set { _head = value; } }
    public Gear Bottom    {get { return _bottom; }private set { _bottom = value; }}
    public Gear Belt
    {
        get { return _belt; }
        private set { _belt = value; }
    }
    public Gear Shoes
    {
        get { return _shoes; }
        private set { _shoes = value; }
    }
    public Gear Shoulder
    {
        get { return _shoulder; }
        private set { _shoulder = value; }
    }

    
    public List<Gear> Inven { get { return _inventory; } }

    //target is gear player picked, origin is the gear player equiped
    //change it, return a Gear? type, then apply the return value to mousrtarget?
    //return the being swapped gear index?
    public int ApplyEquipment(Gear mousetarget)
    {
        Armor armor;
        armor = mousetarget.armorType;
        int gearIndex=-1;
        switch (armor) {
            case Armor.Head:
                gearIndex=Head.GetIndex(Inven);
                Head = mousetarget;
                break;
            case Armor.Shoulder:
                gearIndex = Shoulder.GetIndex(Inven);
                Shoulder = mousetarget;
                break;
            case Armor.Bottom:
                gearIndex = Bottom.GetIndex(Inven);
                Bottom = mousetarget;                
                break;
            case Armor.Belt:
                gearIndex = Belt.GetIndex(Inven);
                Belt = mousetarget;
                break;
            case Armor.Shoes:
                gearIndex = Shoes.GetIndex(Inven);
                Shoes = mousetarget;
                break;
            default:
                break;
        }
        //just try
        return gearIndex;
        
    }


    public void AddInventory(Gear loot)
    {
        if (loot != null)
        {
            _inventory.Add(loot);
        }
        else return;
    }
}
