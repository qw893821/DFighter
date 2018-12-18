using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomizeController
{
    public delegate void DeathDg();
    public class GameManager : MonoBehaviour
    {
        public static DeathDg DeathHandler;

        // Update is called once per frame
        void Update()
        {
            if (DeathHandler != null)
                DeathHandler();
        }
    }
}
