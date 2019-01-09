using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

namespace CustomizeController
{
    
    public delegate void DeathDg();
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager GM { get { return _instance; } }

        //change approach, let loo find data in their own variable collection
        //public ItemCollection IteamCollection;

        public DeathDg DeathHandler;



        //public test val;
        public GameObject LootGO;

        public GameObject player;

        public GameObject cameraGO;
        public GameObject infoUI;

        //test private target
        private GameObject mouseTarget;


        bool test = false;
        GameObject curGO;

        public GameObject uiCanvas;

        //redo this part, base on current design, make it a dictionary could make it work.
        //public List<GameObject> Slots = new List<GameObject>();
        Dictionary<GameObject, Gear> inventorydic=new Dictionary<GameObject, Gear>();
        //Dictionary<GameObject, Gear> bodySlots = new Dictionary<GameObject, Gear>();
        private List<Gear> gears = new List<Gear>();

        public bool _____________;

        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            //instanitate the dictionary key, temp name "itembox in"
            //#region CreatebodySlots
            //var bodyGO = GameObject.Find("UICanvas").transform.Find("PlayerGearUI");
            //foreach (Transform ts in bodyGO.transform)
            //{
            //    bodySlots.Add(ts.gameObject, null);
            //}
            //#endregion
            /*
             * mixing the inventory and gear slots.
             * first five will be the slots for current equiped gear
             * and furture proof. when add more solt, will auto add more pair to the dictionary.
             */
            #region CreatebodySlots
            var bodyGO = GameObject.Find("UICanvas").transform.Find("PlayerGearUI");
            foreach (Transform ts in bodyGO.transform)
            {
                inventorydic.Add(ts.gameObject, null);
            }
            #endregion
            #region CreateInventory
            var pouchGO = uiCanvas.transform.Find("ItemBoxIN");
            foreach (Transform ts in pouchGO.transform)
            {
                inventorydic.Add(ts.gameObject, null);
            }
            #endregion

            //var hs = player.GetComponent<HeroStatus>();
            //var key0 = inventorydic.ElementAt(0).Key;
            //inventorydic[key0] = hs.Char.Head;
            //var key3 = inventorydic.ElementAt(1).Key;
            //inventorydic[key3] = hs.Char.Shoulder;
            //var key1 = inventorydic.ElementAt(2).Key;
            //inventorydic[key1] = hs.Char.Bottom;
            //var key4 = inventorydic.ElementAt(3).Key;
            //inventorydic[key4] = hs.Char.Belt;
            //var key2 = inventorydic.ElementAt(4).Key;
            //inventorydic[key2] = hs.Char.Shoes;
            //foreach (KeyValuePair<GameObject, Gear> pair in inventorydic.Where(pair=>pair.Value!=null))
            //{
            //    pair.Key.GetComponent<Image>().sprite = pair.Value.icon;
            //}
            Inventory.InitialGear(inventorydic,player);
        }

        private void Start()
        {
            
            infoUI.SetActive(false);

            //get the instantiated reference
            //this will not matter when hero is not instantiated.
            //gears = player.GetComponent<HeroStatus>().Char.Inventory;

            //#region testshowgear
            //var hs = player.GetComponent<HeroStatus>();
            //var key0 = bodySlots.ElementAt(0).Key;
            //bodySlots[key0] = hs.Char.Head;
            //var key1 = bodySlots.ElementAt(1).Key;
            //bodySlots[key1] = hs.Char.Bottom;
            //var key2 = bodySlots.ElementAt(2).Key;
            //bodySlots[key2] = hs.Char.Shoes;
            //var key3 = bodySlots.ElementAt(3).Key;
            //bodySlots[key3] = hs.Char.Shoulder;
            //var key4 = bodySlots.ElementAt(4).Key;
            //bodySlots[key4] = hs.Char.Belt;
            //#endregion
            //foreach (KeyValuePair<GameObject, Gear> pair in bodySlots)
            //{
            //    pair.Key.GetComponent<Image>().sprite = pair.Value.icon;
            //}
        }


        // Update is called once per frame
        void Update()
        {
            DeathHandler?.Invoke();
            CameraFollow(cameraGO, player);
            //test ui,works.
            UIController.ActiveUIDisplayerHandler(uiCanvas,"i");

            //Inventory.InventoryUpdate(gears,inventorydic);
            //Inventory.InventoryAdd(gear, inventorydic);

            //update the gear ui
            
            //foreach (KeyValuePair<GameObject, Gear> pair in bodySlots)
            //{
            //    pair.Key.GetComponent<Image>().sprite = pair.Value.icon;
            //}
            

        }

        void CameraFollow(GameObject camera, GameObject player)
        {
            Vector3 targetPos;
            //z offset
            float zoffset, yoffset;
            targetPos = player.transform.position;
            yoffset = camera.transform.position.y - targetPos.y;
            zoffset = camera.transform.position.z - targetPos.z;
            targetPos.y += yoffset;
            targetPos.z = zoffset;
            camera.transform.position = targetPos;
        }

        public void Loot(Vector3 pos)
        {
            Instantiate(LootGO, pos, Quaternion.identity);
        }


        void OnGUI()
        {
            Event e = Event.current;
            GraphicRaycaster m_raycast;
            EventSystem m_event;
            PointerEventData m_pointerData;
            #region inefficent part
            GameObject uiCanvas;
            uiCanvas = GameObject.Find("UICanvas");
            m_raycast = uiCanvas.GetComponent<GraphicRaycaster>();
            m_event = uiCanvas.GetComponent<EventSystem>();
            m_pointerData = new PointerEventData(m_event);

            #endregion
            if (e.button == 1 && e.isMouse)
            {

                m_pointerData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                m_raycast.Raycast(m_pointerData, results);
                foreach (RaycastResult result in results)
                {
                    curGO = result.gameObject;
                }
                test = true;
            }
            else { test = false; }
            
        }

        public void InventoryTestFunc()
        {
            var hs = player.GetComponent<HeroStatus>();
            if (test)
            {
                try
                {
                    //Inventory.InventoryConsume(inventorydic,curGO,true, hs);
                    Inventory.InventoryConsume(inventorydic, curGO,hs);
                    Inventory.InitialGear(inventorydic, player);
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        /*public */void UpdateInventory(Gear gear)
        {
            //here i update inventory
            Debug.Log("here i update inventory");
            Inventory.InventoryAdd(gear, inventorydic);
        }
        
    }
}
