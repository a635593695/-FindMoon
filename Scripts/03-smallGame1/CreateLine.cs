using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts._02_outHome;
using Assets.Scripts._06_inHouse;
using System.Collections;

namespace Assets.Scripts._03_smallGame1
{
    public class CreateLine:MonoBehaviour
    {
        public static CreateLine _instance;
        private GameObject camera;
        //这里我们分析一下需求，第一我们要实现连线的功能，即我们选中一个方块，生成一个点，点击第二个方块，在它的中心生成一个点，然后在两个点中间连线
        //所以我们先要在Vector3.zero生成一个点作为标记
        //这个脚本是挂在每个物体自己身上
        //还有个逻辑，当我们已经用一个点作为桥梁的时候，后面的点不能拿它当桥梁，因此我们要一个集合存储这些点
        public static bool isShow = true;
        [HideInInspector]
        public static int index = 0;
        [HideInInspector]
        public List<Vector3> beUserdTransform = new List<Vector3>();
        public Material lineMaterlial;
       // private List<Transform> lineRenderList = new List<Transform>();
        private List<GameObject> lineImageList = new List<GameObject>();
        [HideInInspector]
        public static bool nowPoint = false;
        [HideInInspector]
        public static Vector3 pointPosition;
        private Vector3 newPosition = Vector3.zero;
        public static string nowTag="1";
        private bool isClick = false;
        public static int i = 0;
        private GameObject manyLine;
        [HideInInspector]
        public static bool canUse = true;
        
        private GameObject mainCamera;
        [HideInInspector]
        public static bool a1 = true;
        //[HideInInspector]
        //public static bool a2 = true;
        //[HideInInspector]
        //public static bool a3 = true;
        //[HideInInspector]
        //public static bool a4 = true;
        //[HideInInspector]
        //public static bool a5 = true;
        //[HideInInspector]
        //public static bool a6 = true;
        //[HideInInspector]
        //public static bool a7 = true;
        //[HideInInspector]
        //public static bool a8 = true;
        //[HideInInspector]
        //public static bool a9 = true;
        
        public GameObject henImage;
        public GameObject shuImage;
        private float time;

        //这里是记录当前已经成功连接了几个，当到达4的时候，代表通过
        [HideInInspector]
        public static int overI = 0;
        private GameObject diaLog;
        private GameObject dialog;
        [HideInInspector]
        
        private void Awake()
        {
            camera = GameObject.Find("camera");
            diaLog = GameObject.Find("ControllerDiaLog") as GameObject;
            dialog = diaLog.transform.Find("DiaLog").gameObject;
            mainCamera = GameObject.Find("Main Camera");
            //因为画线一个GameObject只能画一条线
            manyLine = GameObject.Find("manyLine");
            if (_instance != null)
            {
                _instance = this;
            }
            
            foreach (Transform t in manyLine.transform)
            {
               // lineRenderList.Add(t);
            }
            beUserdTransform.Add(manyLine.transform.position);
            //beUserdTransform.Add(manyLine.transform.position);
            i = 0;
           
            //beUserdTransform.Clear();

            nowPoint = false;


        }
       
        private void Update()
        {

            //if (Input.GetMouseButtonDown(1))
            //{

            if (overI == 4)
            {
                OnBoxClick.canJumpScene = false;
                OnBoxClick.canJumpScene2 = true;
                mainCamera.GetComponent<ControlManager>().StartSplash(6, 2);
               
                
            }
            

           

            //}

        }
        
        public void OnRestClick()
        {
            //beUserdTransform.Add(manyLine.transform.position);
            //for (int i = 0; i < lineRenderList.Count; i++)
            //{
            //    Destroy(lineRenderList[i].GetComponent<LineRenderer>());
            //}
            index++;
            
            a1 = true;
           
            
            
            for (int i = 0; i < lineImageList.Count; i++)
                {
                Destroy(lineImageList[i].gameObject);
                }
                i = 0;
            overI = 0;
            //beUserdTransform.Clear();

            nowPoint = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void IsUsed(Vector3 pointPosition)
        {

            foreach (Vector3 t in beUserdTransform)
            {


                if (t == pointPosition)
                {
                    //这里会遍历所有的点，如果有一个点和目前点击的点相等，代表该点已经被使用过，就不能进行画线操作
                    // Debug.Log("false操作被设置");
                    canUse = false;
                }
            }
        }
        private void CreatePonit(RaycastHit2D ray)
        {
            //Debug.Log(ray.collider.tag == nowTag + "1" || ray.collider.tag == nowTag.Remove(nowTag.Length - 1, 1));
            //这个是抽象出来的用来生成点的方法
            //1.这个是确立点的位置坐标，确定之后就有原点了

            //2.生成原点后就要设置为true，如果为false才能生成原点，不然都是做连线操作，这里两重判断，如果为false，记录原点
            //更改为true，如果为true的话，代表当前有原点，我们就要将这个点和该原点连接起来，并且设置这个点为新的原点
            //连接之前也要进行判断，首先我们将我们当前生成原点的tag保存起来，然后连接时判断如果是normalBlock，则建立连接，如果是自身tag
            //也建立连接并且将原点置空，以达到可以生成新的原点

            //现在要改变一下画线思路，假设不是原点，如果是y轴差3的话，就在该物体上实例化竖着的绳子，并且Vector3=(0,1.5,0)，如果是x轴差3的话，就实例化横着
            //的绳子，并且x轴加1.5,然后每次实例化出来了，我们都要
            //  RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
           // Debug.Log(nowTag);

            {
                if (nowPoint == true)
                {

                    //for (int i = 0; i < lineRenderList.Count; i++)
                    //{
                    //    if(lineRenderList[i].GetComponent<LineRenderer>()==null)
                    //    lineRenderList[i].gameObject.AddComponent<LineRenderer>();
                    //    lineRenderList[i].GetComponent<LineRenderer>().material = lineMaterlial;
                    //    lineRenderList[i].GetComponent<LineRenderer>().startWidth = 0.4f;
                    //    lineRenderList[i].GetComponent<LineRenderer>().endWidth = 0.4f;
                    //}

                    newPosition = ray.collider.transform.position;
                    if (ray.collider.tag == "normalBlock")
                    {
                        if (pointPosition.x == newPosition.x || pointPosition.y == newPosition.y)
                        {

                            //添加坐标应该在决定画线后进行，画线之后这两个点都不能作为连接中介

                            //Debug.Log("进行了画线操作" + pointPosition + newPosition);
                            //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(0, pointPosition);
                            //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(1, newPosition);

                            //这里应该实例化
                            if (nowTag != "normalBlock")
                            {
                                if ((pointPosition.x - newPosition.x) == 3)
                                {
                                    GameObject o = GameObject.Instantiate(henImage, transform);
                                    o.transform.SetParent(transform);
                                    o.transform.position = o.transform.parent.position;
                                    o.transform.position = new Vector3(o.transform.position.x + 1.5f, o.transform.position.y, o.transform.position.z);
                                    lineImageList.Add(o);
                                    beUserdTransform.Add(pointPosition);
                                    beUserdTransform.Add(newPosition);


                                    //这里每次连接完后会保存这个pointPosition
                                    pointPosition = newPosition;
                                    i++;
                                }
                                if ((pointPosition.x - newPosition.x) == -3)
                                {
                                    GameObject o = GameObject.Instantiate(henImage, transform);
                                    o.transform.SetParent(transform);
                                    o.transform.position = o.transform.parent.position;
                                    o.transform.position = new Vector3(o.transform.position.x - 1.5f, o.transform.position.y, o.transform.position.z);
                                    lineImageList.Add(o);
                                    beUserdTransform.Add(pointPosition);
                                    beUserdTransform.Add(newPosition);


                                    //这里每次连接完后会保存这个pointPosition
                                    pointPosition = newPosition;
                                    i++;
                                }
                                if ((pointPosition.y - newPosition.y) == 3)
                                {
                                    GameObject o = GameObject.Instantiate(shuImage, transform);
                                    o.transform.SetParent(transform);
                                    o.transform.position = o.transform.parent.position;
                                    o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 1.5f, o.transform.position.z);
                                    lineImageList.Add(o);
                                    beUserdTransform.Add(pointPosition);
                                    beUserdTransform.Add(newPosition);


                                    //这里每次连接完后会保存这个pointPosition
                                    pointPosition = newPosition;
                                    i++;
                                }
                                if ((pointPosition.y - newPosition.y) == -3)
                                {
                                    GameObject o = GameObject.Instantiate(shuImage, transform);
                                    o.transform.SetParent(transform);
                                    o.transform.position = o.transform.parent.position;
                                    o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
                                    lineImageList.Add(o);
                                    beUserdTransform.Add(pointPosition);
                                    beUserdTransform.Add(newPosition);


                                    //这里每次连接完后会保存这个pointPosition
                                    pointPosition = newPosition;
                                    i++;
                                }
                            }
                            
                            //beUserdTransform.Add(ray.collider.transform.position);

                          


                        }
                    }



                    else if (ray.collider.tag == nowTag + "1" || ray.collider.tag == nowTag.Remove(nowTag.Length - 1, 1))
                    {
                        if (pointPosition.x == newPosition.x || pointPosition.y == newPosition.y)
                        {
                            if ((pointPosition.x - newPosition.x) == 3)
                            {
                                GameObject o = GameObject.Instantiate(henImage, transform);
                                o.transform.SetParent(transform);
                                o.transform.position = o.transform.parent.position;
                                o.transform.position = new Vector3(o.transform.position.x + 1.5f, o.transform.position.y, o.transform.position.z);
                                lineImageList.Add(o);
                                beUserdTransform.Add(newPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(0, pointPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(1, newPosition);
                                overI++;
                                i++;
                                a1 = true;
                                nowPoint = false;
                            }
                            if ((pointPosition.x - newPosition.x) == -3)
                            {
                                GameObject o = GameObject.Instantiate(henImage, transform);
                                o.transform.SetParent(transform);
                                o.transform.position = o.transform.parent.position;
                                o.transform.position = new Vector3(o.transform.position.x - 1.5f, o.transform.position.y, o.transform.position.z);
                                lineImageList.Add(o);
                                beUserdTransform.Add(newPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(0, pointPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(1, newPosition);
                                overI++;
                                i++;
                                a1 = true;
                                nowPoint = false;
                            }
                            if ((pointPosition.y - newPosition.y) == 3)
                            {
                                GameObject o = GameObject.Instantiate(shuImage, transform);
                                o.transform.SetParent(transform);
                                o.transform.position = o.transform.parent.position;
                                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y + 1.5f, o.transform.position.z);
                                lineImageList.Add(o);
                                beUserdTransform.Add(newPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(0, pointPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(1, newPosition);
                                overI++;
                                i++;
                                a1 = true;
                                nowPoint = false;
                            }
                            if ((pointPosition.y - newPosition.y) == -3)
                            {
                                GameObject o = GameObject.Instantiate(shuImage, transform);
                                o.transform.SetParent(transform);
                                o.transform.position = o.transform.parent.position;
                                o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y - 1.5f, o.transform.position.z);
                                lineImageList.Add(o);
                                beUserdTransform.Add(newPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(0, pointPosition);
                                //lineRenderList[i].GetComponent<LineRenderer>().SetPosition(1, newPosition);
                                overI++;
                                i++;
                                a1 = true;
                                nowPoint = false;
                            }

                            

                            //这里是确定创建连接

                        }



                    }
                }


                else
                {
                    pointPosition = ray.collider.transform.position;




                    //这里保存当前连接的点的tag
                    nowTag = ray.collider.tag;
                    if (nowTag != "normalBlock" && nowTag == ray.collider.tag)
                    {

                        nowPoint = true;

                        //beUserdTransform.Add(ray.collider.transform);
                        // Debug.Log("创建了原点" + nowTag);
                    }
                    //如果想要开启新的连接
                    else if (nowTag != ray.collider.tag)
                    {
                        nowPoint = false;
                    }
                    else
                    {
                        nowTag = null;
                        nowPoint = false;
                    }



                }

            }
        }
            private void OnMouseDown()
        {
            RaycastHit2D ray = Physics2D.Raycast(camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //beUserdTransform.Add(manyLine.transform.position);
            canUse = true;
           // Debug.Log(ray.collider.transform.position);
            IsUsed(ray.collider.transform.position);
            //这个添加应该是在做出连线决定后再加才对
               // beUserdTransform.Add(ray.collider.transform.position);
            
            
            
            
            
            //foreach (Transform t in beUserdTransform)
            //{
            //    Debug.Log(t.position);
            //}

            // Debug.Log(ray.collider);
            //检测点击事件应该放在点击方块时候，如果没有匹配的点，才会继续操作
            //Debug.Log(IsUsed(ray.collider.transform.position));

            if (canUse)
            {
                if (ray.collider != null)
                {
                    switch (ray.collider.tag)
                    {
                        case "normalBlock":
                            //如果点击的是普通方块，不创建原点
                            
                            
                                CreatePonit(ray);
                            break;
                        case "redBlock":
                            //Debug.Log("点击了红色方块");
                            //点击之后，我们就要先进行判断当前是否有原点
                            if (a1 == true)
                            {
                               
                                {
                                    CreatePonit(ray);
                                    
                                    
                                }
                            }
                            break;
                        case "blueBlock":
                            if (a1 == true)
                            {
                                
                                {
                                    CreatePonit(ray);
                                  
                                   
                                }
                               
                            }
                            break;
                        case "yellowBlock":
                            if (a1 == true)
                            {
                                
                                {
                                    CreatePonit(ray);
                                    
                                    
                                }
                                
                            }
                            break;
                        case "greenBlock":
                            if (a1 == true)
                            {
                                
                                {
                                    CreatePonit(ray);
                                    
                                    
                                }
                              
                            }
                            break;
                        case "redBlock1":
                            //Debug.Log("点击了红色方块");
                            //点击之后，我们就要先进行判断当前是否有原点
                            if (a1 == true)
                            {
                                
                                {
                                    CreatePonit(ray);
                                    
                                    
                                }
                                
                            }

                            break;
                        case "blueBlock1":
                            if (a1 == true)
                            {
                               
                                {
                                    CreatePonit(ray);
                                    
                                   
                                }
                               
                            }
                            break;
                        case "yellowBlock1":
                            if (a1 == true)
                            {
                               
                                {
                                    CreatePonit(ray);
                                   
                                   
                                }
                                
                            }
                            break;
                        case "greenBlock1":
                            if (a1 == true)
                            {
                               
                                {
                                    CreatePonit(ray);
                                    
                                  
                                }
                               
                            }
                            break;
                    }
                }
            }
           
            
        }
        private void OnBlockClick()
        {
            //这里要确定的是当我们点击这个方块的时候，会根据方块的标签生成不同的点，这个也是我们连线开始的原点，一旦这个原点生成了，后续不会
            //生成原点，而是会进行点与点的连接，那我们这里怎么做线段的连接？用lineRender进行画线
            //这里的话首先我们用2d射线来获得当前点击到的是哪个方块
           
          
        }
       




    }
}
