using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts._01_gameStart
{
    class StartButton:MonoBehaviour
    {
        private Animator animator;
        private void Start()
        {
            animator = GetComponent<Animator>();
            animator.speed = 0.3f;
        }
        public void OnStartButtonClick()
        {
            
            SceneManager.LoadScene("2");
            
        }
    }
}
