using Assets.Scripts._02_outHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts._05_horseWorker
{
    class Start:MonoBehaviour
    {
        private GameObject diaLog;
        private GameObject dialog;
        private void Awake()
        {
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;
            dialog.SetActive(true);
        }


    }
}
