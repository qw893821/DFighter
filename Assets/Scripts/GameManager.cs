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


        public void TestDebugFunc()
        {
                Debug.Log("test func fired");
        }
    }
}
