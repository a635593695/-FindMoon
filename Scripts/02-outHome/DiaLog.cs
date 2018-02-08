using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

namespace Assets.Scripts._02_outHome
{
    public class DiaLog:MonoBehaviour
    {
        private bool isDialogChange = false;
        //在这里的话我，我们是要做到对话框的更新显示，如果收集齐所有物品，更新对话然后加载到下一场景
        private Text dialogText;
        private bool isChange=false;
        private GameObject diaLog;
        private GameObject dialog;
        private GameObject mainCamera;

        
        private void Awake()
        {
            dialogText = transform.Find("Text").GetComponent<Text>();
            mainCamera = GameObject.Find("Main Camera");
            


        }
       //public static IEnumerator ChangeMask()
       // {
       //     //这里会先切换Alpha值，然后进行转场，转场大概需要一秒的变换时间，这里我们会进行一个判断
       //     //我们会保存一个当前场景的场景名，如果相同，则不变，如果不同，就从0变成1
       //     //保存场景名会放在发生转场的时候
       //     Debug.Log(int.Parse(SceneManager.GetActiveScene().name) + 1);
       //     Color color = Color.black;
       //     color.a = 255;
       //     Image ima = GameObject.Find("changeMask").GetComponent<Image>();
       //     ima.DOColor(color, 2f);
       //     yield return new WaitForSeconds(2f);
       //     Debug.Log(int.Parse(SceneManager.GetActiveScene().name) + 1);
       //     if (SceneManager.GetActiveScene().name != "6")
       //     {
       //         SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
       //         Debug.Log(int.Parse(SceneManager.GetActiveScene().name) + 1);
       //     }
       //     else if(SceneManager.GetActiveScene().name == "6")
       //     {
       //         SceneManager.LoadScene("4");
       //     }
            
       // }
       // public static IEnumerator ShowMask()
       // {
       //     Color color = Color.black;
       //     color.a = 0;
       //     Image ima = GameObject.Find("changeMask").GetComponent<Image>();
       //     ima.DOColor(color, 2f);
       //     yield return new WaitForSeconds(2f);
       // }
        private void Update()
        {
            
            
            if (isDialogChange == false)
            {
                OnFiveScene();
            }
           
               
        }
        //public void OnChangeScene()
        //{
        //    //在这里进行判断，如果收集齐全物体，就会更新text到下一个场景，那这里有个取巧的办法，我们第四个场景中共要收集三个物体，
        //    //假设背包栏已经有三个物体了，那么就判断收集完全
            
        //    SceneManager.LoadScene("5");
        //    Debug.Log("调用了");
        //}
        //这里还有一个需求，如果当前场景是车夫场景的话，我们要加载第一段对话，也就是天下雨了，麻烦了

        private void OnFiveScene()
        {
            if (SceneManager.GetActiveScene().name == "3")
            {

                dialogText.text = "天下雨了，麻烦了";
                isDialogChange = true;
            }



        }



        
    }
}
