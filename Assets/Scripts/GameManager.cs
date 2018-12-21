using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomizeController
{
    
    public delegate void DeathDg();
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager GM { get { return _instance; } }
        



        public DeathDg DeathHandler;

        //public test val;
        public GameObject player;
        public GameObject cameraGO;
        public GameObject infoUI;

        //test private target
        private GameObject mouseTarget;


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
            if (DeathHandler != null)
                DeathHandler();
            CameraFollow(cameraGO, player);
        }

        void CameraFollow(GameObject camera,GameObject player)
        {
            Vector3 targetPos;
            //z offset
            float zoffset;  
            targetPos = player.transform.position;
            zoffset = camera.transform.position.z - targetPos.z;
            targetPos.z = zoffset;
            camera.transform.position = targetPos;
        }

        
    }
}
