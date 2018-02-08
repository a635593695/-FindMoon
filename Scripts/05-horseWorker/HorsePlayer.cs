using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._05_horseWorker
{
    public class HorsePlayer : MonoBehaviour
    {
        //这里要做的就是点击到马车夫，就要显示对话框并且更新文本
        //private GameObject dialog;
        public static bool isTalk = true;
        public Sprite[] horseImage;
        private GameObject diaLog;
        private GameObject dialog;

        private void Start()
        {
           // dialog = GameObject.Find("ControllerDiaLog/DiaLog") as GameObject;
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;
        }
        void Update()
        {
            //从角色位置向NPC发射一条经过鼠标位置的射线  
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mHi;
            //判断是否击中了NPC  
            if (Physics.Raycast(mRay, out mHi))
            {
                //如果击中了NPC  
                if (Input.GetMouseButton(0))
                {
                    if (mHi.collider.gameObject.tag == "horseWorker")
                    {
                        //进入对话状态  
                        if (UseUmbrella.useUmbrella == true)
                        {
                            if (isTalk == true)
                            {
                                dialog.SetActive(true);
                                dialog.transform.Find("Text").GetComponent<Text>().text = "这大晚上的，银子要是没给够，我是不会去的！";
                                dialog.transform.Find("HeadImage").GetComponent<Image>().sprite = horseImage[0];

                            }
                        }
                       

                    }
                }

            }
        }

    }
}

