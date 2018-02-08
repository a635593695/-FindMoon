using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._03_smallGame1
{
    class ControlDiaLog2:MonoBehaviour
    {
        private GameObject diaLog;
        private GameObject dialog;
        private bool show = true;
        private void Awake()
        {
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;
        }
        private void Update()
        {
            if (CreateLine.index == 3)
            {
                if (show)
                {
                    StartCoroutine(ChangeDialog());
                    
                }

            }
        }
        IEnumerator ChangeDialog()
        {

            {
                dialog.SetActive(true);
                dialog.transform.Find("Text").GetComponent<Text>().text = "耐心点，一个子一个子地连好相同类的棋子，能破解的";

                yield return new WaitForSeconds(2.5f);
               
                dialog.SetActive(false);
                show = false;

            }

        }



    }
}
