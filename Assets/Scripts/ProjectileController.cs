using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomizeController
{
    public delegate void ProjectileMoveDg();
    public delegate void UIDisplayDg();


    public delegate void RegisterDg();

    public class ProjectileController : MonoBehaviour
    {
        public static ProjectileMoveDg PMoveDg;
        public static UIDisplayDg UIdisplay;

        // Use this for initialization

        // Update is called once per frame
        void Update()
        {
            if (PMoveDg != null)
                PMoveDg();
            if (UIdisplay != null)
                UIdisplay();
            
        }
    }

}
