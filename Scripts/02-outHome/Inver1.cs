using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts._02_outHome
{
   public class Inver1:MonoBehaviour
    {
        private Image hideMask;
        private void Awake()
        {
            hideMask = GameObject.Find("hideMask").GetComponent<Image>();
        }
        private void Update()
        {
            if (SceneManager.GetActiveScene().name == "5")
            {
                Color color = Color.black;
                color.a = 255;
                hideMask.color = color;
            }
            else
            {
                Color color = Color.black;
                color.a = 0;
                hideMask.color = color;
            }
        }
    }
}
