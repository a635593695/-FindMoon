using Assets.Scripts._02_outHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._07_InTheBox
{
    class IfShow:MonoBehaviour
    {
        public GameObject mirror;
        public GameObject knife;
        private void Awake()
        {
            //这里的话是每次加载场景进行一个判断，如果已经获取了就不再显示
            if (GetItem.boo2 == true)
            {
                knife.SetActive(false);
            }
            if (GetItem.boo3 == true)
            {
                mirror.SetActive(false);
            }

        }


    }
}
