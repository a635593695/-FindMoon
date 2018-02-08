using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._07_InTheBox
{
    class Class1:MonoBehaviour
    {
        //这里就是点击按钮跳转页面了
        private Button changeButton;
        private GameObject mainCamera;
        private void Awake()
        {
            changeButton = GetComponent<Button>();
            changeButton.onClick.AddListener(OnButtonClick);
            mainCamera = GameObject.Find("Main Camera");
        }
        private void OnButtonClick()
        {
            mainCamera.GetComponent<ControlManager>().StartSplash(4, 2);
        }


    }
}
