using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts._03_smallGame1
{
    class BackTheHorse:MonoBehaviour
    {
        private Button backButton;
        private GameObject mainCamera;
        
        private void Awake()
        {
            mainCamera = GameObject.Find("Main Camera");
            backButton = GetComponent<Button>();
            backButton.onClick.AddListener(OnBackClick);
        }
        private void OnBackClick()
        {
            mainCamera.GetComponent<ControlManager>().StartSplash(4, 2);
        }



    }
}
