using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._06_inHouse
{
    class CloseDialog:MonoBehaviour
    {
        private GameObject diaLog;
        private GameObject dialog;
        private void Awake()
        {
            
        diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
             dialog = diaLog.transform.Find("DiaLog").gameObject;
            dialog.SetActive(false);
    }
    }
}
