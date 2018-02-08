using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts._02_outHome;

namespace Assets.Scripts._06_inHouse
{
   public class OnBoxClick:MonoBehaviour
    {
        //这里点击箱子后，应该跳转到小游戏场景03-game
        private Button boxButton;
        public  static bool canJumpScene=true;
        public static bool canJumpScene2 = false;
        public Sprite openBox;
        private Image boxImage;
        private GameObject mainCamera;
        private void Awake()
        {
            mainCamera = GameObject.Find("Main Camera");
            boxButton = GetComponent<Button>();
            boxButton.onClick.AddListener(OnClick);
            boxImage = GetComponent<Image>();

        }
        private void Update()
        {
            if (canJumpScene == false)
            {
                boxImage.sprite = openBox;
            }
        }
        private void OnClick()
        {
            if (canJumpScene)
            {
                mainCamera.GetComponent<ControlManager>().StartSplash(5, 2);
               // Application.LoadLevelAdditive("5");

                
                
                boxImage.sprite = openBox;
            }
            if (canJumpScene2 == true)
            {
                mainCamera.GetComponent<ControlManager>().StartSplash(6, 2);
            }
            
        }


    }
}
