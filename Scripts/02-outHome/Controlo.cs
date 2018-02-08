using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts._02_outHome
{
    class Controlo:MonoBehaviour
    {
        [HideInInspector]
        public static List<Invertory> invertoryList = new List<Invertory>();
        private GameObject mainCamera;
        private void Awake()
        {
            if (GameObject.Find("Invertory").GetComponentsInChildren<Invertory>() != null)
            {
                invertoryList.Clear();
                foreach (Invertory item in GameObject.Find("Invertory").GetComponentsInChildren<Invertory>())
                {
                    //遍历子物体将背包都添加到list集合当中
                    invertoryList.Add(item);


                }
            }
            mainCamera = GameObject.Find("Main Camera");
        }
        private void Update()
        {
            if (GetItem.isLoadScene2 == false)
            {
                if (GetItem.boo1 == true && GetItem.boo2 == true && GetItem.boo3 == true)
                {
                    mainCamera.GetComponent<ControlManager>().StartSplash(7, 2);

                    GetItem.isLoadScene2 = true;
                }
            }
        }
    }
}
