using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Assets.Scripts._00_createrShow
{
    public class CreaterShow:MonoBehaviour
    {
        //这里控制的是开头两个字幕的切换
        public Image zhuiyueImage;
        public Image mengxiangImage;
        IEnumerator ChangeName()
        {
            //用协程控制动画顺序
            
            Color color = Color.white;
            color.a = 1;
            zhuiyueImage.DOColor(color, 2f);
            yield return new WaitForSeconds(2f);
            color.a = 0;
            zhuiyueImage.DOColor(color, 2f);
            yield return new WaitForSeconds(2f);
            color.a = 1;
            mengxiangImage.enabled = true;
            mengxiangImage.DOColor(color, 2f);
            yield return new WaitForSeconds(2f);
            color.a = 0;
            mengxiangImage.DOColor(color, 2f);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("1");
        }
        public void Start()
        {
            
            mengxiangImage.enabled = false;
            StartCoroutine(ChangeName());
        }


    }
}
