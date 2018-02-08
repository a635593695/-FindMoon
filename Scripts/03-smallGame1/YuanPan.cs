using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts._03_smallGame1
{
    public class YuanPan : MonoBehaviour
    {
        private void Awake()
        {
           
        }
        private void Update()
        {
            
        }
        public void OnRestClick()
        {
            SceneManager.LoadScene(0);
        }

    }
}
