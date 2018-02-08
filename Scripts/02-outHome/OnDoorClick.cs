using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Assets.Scripts._03_smallGame1;

namespace Assets.Scripts._02_outHome
{
    class OnDoorClick : MonoBehaviour
    {
        //这个就是挂在门上，如果三个物品都收集到并且点击，就跳转
        private Button onDoorClick;
        private bool isChange = false;
        private Text dialogText;
        private GameObject mainCamera;
        private GameObject diaLog;
        private GameObject dialog;
        private bool isShow = true;
        private bool isShow2 = true;
        private float time = 0f;
        private void Awake()
        {
            onDoorClick = GetComponent<Button>();
            mainCamera = GameObject.Find("Main Camera");
            dialogText = GameObject.Find("DiaLog/Text").GetComponent<Text>();
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;


        }
        IEnumerator ChangeDialog()
        {
           
            {
                dialog.SetActive(true);
                dialog.transform.Find("Text").GetComponent<Text>().text = "快点准备好三件物品出发吧";
                
                yield return new WaitForSeconds(4f);
                
                dialog.SetActive(false);

            }

        }
        private void Update()
        {
            RaycastHit hit;
            time += Time.deltaTime;
            Vector2 mousePosBegan = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosBegan);
            if (isShow)
            {
                if (time >= 4f && time <= 8f)
                {
                    dialog.SetActive(false);
                    isShow = false;
                }
                
            }

            if (isShow2)
            {
                if (time >= 10f)
                {
                    StartCoroutine(ChangeDialog());
                    isShow2 = false;
                }
                
            }
          
            //Is on the legal area:  
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("door"))
                {
                    if (isChange == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (GetItem.itemList.Count == 3 && SceneManager.GetActiveScene().name == "2")
                            {
                                mainCamera.GetComponent<ControlManager>().StartSplash(3, 2);

                                isChange = true;

                            }
                        }

                    }
                   
                }
                //else if(hit.collider.tag.Equals("back"))
                //{
                //    if (Input.GetMouseButtonDown(0))
                //    {
                //        if (GetItem.itemList.Count != 3 && SceneManager.GetActiveScene().name == "2")
                //        {
                //            StartCoroutine(ChangeDialog());

                //        }
                //    }
                   

                //}
            }



        }
    }
}

