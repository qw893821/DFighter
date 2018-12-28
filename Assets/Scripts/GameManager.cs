﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        public List<GameObject> Slots = new List<GameObject>();

        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }


        }

        private void Start()
        {
            
            infoUI.SetActive(false);
            
        }


        // Update is called once per frame
        void Update()
        {
            DeathHandler?.Invoke();
            CameraFollow(cameraGO, player);
            //test ui,works.
            UIController.ActiveUIDisplayerHandler(uiCanvas,"i");

            InventoryUpdate();
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
            if (test)
            {
                try
                {
                    curGO.

    }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }


        //inventory icon update func
        void InventoryUpdate()
        {
            List<Gear> localgear =new List<Gear>();

            localgear=player.GetComponent<HeroStatus>().Gears;
            for(int i = 0; i < localgear.Count; i++)
            {
                Slots[i].GetComponent<Image>().sprite = localgear[i].icon;
            }
        }
    }
}
