using Assets.Scripts._02_outHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._06_inHouse
{
    class IFYouShow:MonoBehaviour
    {
        public GameObject siJin;
        private void Awake()
        {
            //这里的话是每次加载场景进行一个判断，如果已经获取了就不再显示
            
            if (GetItem.boo1 == true)
            {
                siJin.SetActive(false);
            }

        }
    }
}
