using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts._03_smallGame1
{
    class DiaLogController:MonoBehaviour
    {
        private GameObject diaLog;
        public Sprite[] peopleFace;
        
        private GameObject dialog;
        private void Awake()
        {
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
             dialog = diaLog.transform.Find("DiaLog").gameObject;
            
        }
        private void Start()
        {
            StartCoroutine(ChangeDialog());
        }
        //这里的话我们是控制对话框的变换
        IEnumerator ChangeDialog()
        {
            if (CreateLine.isShow == true)
            {
                dialog.SetActive(true);
                dialog.transform.Find("Text").GetComponent<Text>().text = "规则应该是把金水火土四种棋子以木类棋子为路径，通过点击连接相同类的棋子，才能破解";
                dialog.transform.Find("HeadImage").GetComponent<Image>().sprite = peopleFace[0];
                yield return new WaitForSeconds(5f);
                CreateLine.isShow = false;
                dialog.SetActive(false);
               
            }
           
        }
        




    }
}
