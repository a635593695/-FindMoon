using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts._02_outHome
{
    class GetItem : MonoBehaviour
    {
        //这里要做的就是一个点击事件，当点击到该物体，该物体就会移动到背包栏
        private Button itemButtom;
        private bool isClcik = false;

        public static int i = 0;
        public Sprite[] packageImage;
       
        [HideInInspector]
        public static List<GameObject> itemList = new List<GameObject>();
        [HideInInspector]
        public static bool boo1 = false;
        [HideInInspector]
        public static bool boo2 = false;
        [HideInInspector]
        public static bool boo3 = false;
        public static bool isLoadScene = false;
        public static bool isLoadScene2 = false;
        private GameObject mainCamera;
        private void Start()
        {
            itemButtom = GetComponent<Button>();
            mainCamera = GameObject.Find("Main Camera");
            itemButtom.onClick.AddListener(OnButtonClick);
           // transform.GetComponent<DragItem>().enabled = false;

          
        }
        private void Update()
        {
            //Debug.Log("boo1"+boo1 );
            //Debug.Log("boo2"+boo2);
            //Debug.Log(boo3);
           
            
            //if (isLoadScene == false)
            //{
            //    if (boo1 == false && boo2 == true && boo3 == true)
            //    {
            //        mainCamera.GetComponent<ControlManager>().StartSplash(4, 2);
                    
                    
            //        isLoadScene = true;
            //    }
            //}
           
        }

        IEnumerator ChangeItem(int index)
        {
            
            Color color = Color.white;
            color.a = 0;
            Image image = transform.GetComponent<Image>();
            image.DOColor(color, 1f);
            yield return new WaitForSeconds(1f);
         
            color.a = 1;
            image.DOColor(color, 1f);
            image.sprite = packageImage[index];
            
            if (Controlo.invertoryList[i].transform.childCount < 1)
            {
                transform.SetParent(Controlo.invertoryList[i].transform);
            }
            else
            {
                transform.SetParent(Controlo.invertoryList[i+1].transform);
            }

            transform.position = transform.parent.position;
            i++;
            itemList.Add(transform.gameObject);
            if (i >= Controlo.invertoryList.Count)
            {
                i = 0;
            }
            if (transform.name == "衣服")
            {
              
                transform.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.19f, 1);
            }
            if (transform.name == "伞桶")
            {

                transform.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            }
            if (transform.name == "包裹")
            {

                transform.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            }
            if (transform.name == "小刀")
            {
                boo2 = true;
                transform.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            }
            if (transform.name == "镜子")
            {
                boo3 = true;
                transform.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            }
            if (transform.name == "丝巾")
            {
                boo1 = true;
                transform.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1);
            }
            transform.GetComponent<DragItem>().enabled = true;
            //




        }
        private void OnButtonClick()
        {
            //当我们点击物体时，首先我们要获得这个背包集合，然后往第一个格子添加物品，如果有了物品，就i+1到下一个格子
            //  Debug.Log(invertoryList[i].name);
            if (isClcik == false)
            {
                if (i <= Controlo.invertoryList.Count)
                {

                    //这里话在点击之后我们还有一些工作要做，第二幕场景中点击伞桶得到独立的伞，点击包裹得到银两，因为我这里
                    //处理时候发现Image只能在Canvas下显示，而点击事件又要button来触发，因此我决定每个分开写
                    //处理包裹
                    if (transform.name == "包裹")
                    {
                        StartCoroutine(ChangeItem(0));

                    }
                    if (transform.name == "伞桶")
                    {
                        StartCoroutine(ChangeItem(1));

                    }
                    if (transform.name == "衣服")
                    {
                        StartCoroutine(ChangeItem(2));

                    }
                    if (transform.name == "丝巾")
                    {
                        StartCoroutine(ChangeItem(0));
                        
                    }
                    if (transform.name == "小刀")
                    {
                        StartCoroutine(ChangeItem(0));
                        

                    }
                    if (transform.name == "镜子")
                    {
                        StartCoroutine(ChangeItem(0));
                        
                    }

                    isClcik = true;
                }

            }

        }
    }
}
