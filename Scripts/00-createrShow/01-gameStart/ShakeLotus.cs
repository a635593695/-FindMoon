using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts._01_gameStart
{
    class ShakeLotus:MonoBehaviour
    {
        private bool isAnimOver = false;
        public float speed = 0.1f;
        private Animator lotusAnimator;
        private void Start()
        {
            lotusAnimator = GetComponent<Animator>();
            lotusAnimator.speed = speed;
            
        }
        private void Update()
        {

        }
    }
}
