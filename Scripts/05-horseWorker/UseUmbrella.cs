using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Scripts._02_outHome;

namespace Assets.Scripts._05_horseWorker
{
    public class UseUmbrella : MonoBehaviour, IPointerClickHandler
    {
        //这里的话我们双击伞后后使用掉它并且会修改diaLog中的Text
        private GameObject diaLogText;
        public static bool useUmbrella=false;
        private GameObject mainCamera;
        private bool isUse = false;
        private void Awake()
        {
            diaLogText = GameObject.Find("ControllerDiaLog/DiaLog") as GameObject;
            
                
        }
        private void Update()
        {
            if (isUse == false)
            {
                if (SceneManager.GetActiveScene().name == "3")
                {
                    mainCamera = GameObject.Find("Camera");
                    isUse = true;
                }
            }
            
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.clickCount == 2)
            {
                if (SceneManager.GetActiveScene().name == "3")
                {
                    //如果点击两次就销毁
                    
                    GetItem.i--;
                    diaLogText.transform.Find("Text").GetComponent<Text>().text = null;
                    diaLogText.SetActive(false);
                    useUmbrella = true;
                    Destroy(mainCamera.GetComponent<CameraFilterPack_AAA_WaterDrop>());
                    GetItem.itemList.Remove(transform.gameObject);
                    
                    
                    
                    DestroyImmediate(this.gameObject);
                    
                    for (int i = 1; i < Controlo.invertoryList.Count; i++)
                    {
                        //遍历所有有物品的格子，如果它前面一个格子有物品，那就不移动它不然就将它往前移动一个格子

                        if (Controlo.invertoryList[i].transform.childCount >= 1)
                        {

                            if (Controlo.invertoryList[i - 1].transform.childCount<1)
                            {
                                
                              
                                Controlo.invertoryList[i].transform.GetChild(0).SetParent(Controlo.invertoryList[i - 1].transform);
                                Controlo.invertoryList[i - 1].transform.GetChild(0).position = Controlo.invertoryList[i - 1].transform.GetChild(0).parent.position;

                            }


                        }

                    }
                }

            }
        }
    }
}
