using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loot : MonoBehaviour {

    private Gear _gear;
    [SerializeField]
    private ItemCollection iteamCollection;
    public Gear Gear
    {
        get { return _gear; }
        //set { _gear = value; }
    }

    private void Start()
    {
        _gear = iteamCollection.RandomLoot();
        _gear = Instantiate(_gear);
        transform.GetComponent<SpriteRenderer>().sprite = _gear.icon;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("player loot this, I will be destory");
            Destroy(this.gameObject);
        }
    }


    //private void OnEnable()
    //{
    //    _gear=CustomizeController.GameManager.GM.IteamCollection.RandomLoot();
    //}

}
