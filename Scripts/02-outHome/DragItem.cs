using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Assets.Scripts._05_horseWorker;

namespace Assets.Scripts._02_outHome
{
    public class DragItem : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
    {
        //在这里要实现两个，一个是拖拽，这个使用EventSystem来实现，一个是触碰到对应的碰撞区域消失并且触发对话框的转换
        private RectTransform objectTransform;
        // private GameObject diaLog;
        private GameObject diaLog;
        private GameObject dialog;
        private GameObject mainCamera;
        public Texture2D defaultCursor;
        public Texture2D dragCursor;
        private bool back = true;
        private void Start()
        {
            objectTransform = transform.GetComponent<RectTransform>();
           // diaLog = GameObject.Find("ControllerDiaLog/DiaLog") as GameObject;
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;
            mainCamera = GameObject.Find("Main Camera");
        }
        public void OnDrag(PointerEventData eventData)
        {
            ObjFollowMouse(eventData);
            Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.Auto);
           
        }
        private void ObjFollowMouse(PointerEventData eventData)
        {
            if (transform != null)//检测生成的物体是否为空，保险起见
            {
                RectTransform rc = transform.GetComponent<RectTransform>();//得到生成物品的控制权
                Vector3 globalMousePos;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle
                (objectTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
                {
                    rc.position = globalMousePos;
                    rc.rotation = transform.rotation;
                }
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            ObjFollowMouse(eventData);
            Cursor.SetCursor(dragCursor, Vector2.zero, CursorMode.Auto);

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            switch (transform.name)
            {
                case "包裹":
                    //首先，由自身发出一条射线
                    Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit;

                    Physics.Raycast(myRay, out raycastHit);
                    
                    if (raycastHit.collider != null)
                    {
                        if (raycastHit.collider.tag == "horseWorker")
                        {
                            if (UseUmbrella.useUmbrella == true)
                            {
                                GetItem.itemList.Remove(this.gameObject);
                                DestroyImmediate(this.gameObject);
                                back = false;
                                for (int i = 1; i < Controlo.invertoryList.Count; i++)
                                {
                                    //遍历所有有物品的格子，如果它前面一个格子有物品，那就不移动它不然就将它往前移动一个格子

                                    if (Controlo.invertoryList[i].transform.childCount >= 1)
                                    {

                                        if (Controlo.invertoryList[i - 1].transform.childCount < 1)
                                        {


                                            Controlo.invertoryList[i].transform.GetChild(0).SetParent(Controlo.invertoryList[i - 1].transform);
                                            Controlo.invertoryList[i - 1].transform.GetChild(0).position = Controlo.invertoryList[i - 1].transform.GetChild(0).parent.position;

                                        }


                                    }

                                }

                                dialog.SetActive(false);
                                _05_horseWorker.HorsePlayer.isTalk = false;
                                GetItem.i--;
                                //for(int i = 0; i <= GetItem.invertoryList.Count; i++)
                                //{
                                //    if (GetItem.invertoryList[i].transform.childCount < 1)
                                //    {
                                //        transform.SetParent(GetItem.invertoryList[i].transform);
                                //    }
                                //    else
                                //    {
                                //        transform.SetParent(GetItem.invertoryList[i + 1].transform);
                                //    }
                                //}
                                mainCamera.GetComponent<ControlManager>().StartSplash(4, 2);
                               
                                
                            }
                        }
                        
                            
                        
                    }             
                 break;
            }
            if(back==true)
            transform.position = transform.parent.position;
            //在结束拖拽的时候，进行判断，当前是什么物品，再判断，如果是什么物品，执行什么操作
        }

    }
}
