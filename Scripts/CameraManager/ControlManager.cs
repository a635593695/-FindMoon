﻿using UnityEngine;
using UnityEngine.SceneManagement;






/*

//@author joi 
public class ControlManager : MonoBehaviour
{

    public int guiDepth = 0;

    public string levelToLoad = "";
    //将要加载的场景序号
    public int levelToLoadInt;
    //切换场景的纹理
    public Texture2D splashLogo;
    //淡入淡出的速度
    float fadeSpeed = 0.8f;
    //保持纹理最高透明度的时间
    float waitTime = 0f;
    //是否要等待输入
    public bool waitForInput = false;

    public bool startAutomatically = false;
    //处理切换场景后需要实现的事件
    public delegate void EventHandler();


    public event EventHandler trigger;

   
    public event EventHandler2nd triggerAtLoading;
    //淡入淡出方式
    public enum SplashType

    private float alpha = 0.0f;
    //纹理的状态
    private enum FadeStatus

    private Rect splashLogoPos = new Rect();
    //是否要自适应屏幕大小
    public enum LogoPositioning

    private bool loadingNextLevel = false;

    void Start()

        //      if(startAutomatically)
        //      {
        //          status = FadeStatus.FadeIn;
        //      }
        //      else
        //      {
        //          status = FadeStatus.Paused;
        //      }
        if (logoPositioning == LogoPositioning.Centered)

            splashLogoPos.width = splashLogo.width;

            splashLogoPos.width = Screen.width;

        if (splashType == SplashType.LoadNextLevelThenFadeOut)

        }

        if (SceneManager.sceneCountInBuildSettings <= 1)

    //开始切换，要跳转的场景和设置对应的切换速率
    public void StartSplash(int level, int i)

    }
            case 1:
                fadeSpeed = 0.8f;
                waitTime = 1.0f;
                break;
            case 2:
                fadeSpeed = 0.8f;
                waitTime = 1.0f;
                break;
            case 3:
                fadeSpeed = 0.8f;
                waitTime = 1.0f;
                break;
        if (SceneManager.GetActiveScene().name == "5")
        {
            transform.GetComponent<Camera>().orthographicSize = 9.87f;
        }
        else if(SceneManager.GetActiveScene().name != "5")
        {
            transform.GetComponent<Camera>().orthographicSize = 23.37811f;
        }

        switch (status)
            case FadeStatus.FadeIn:

                alpha += fadeSpeed * Time.deltaTime;
                break;
            case FadeStatus.FadeWaiting:
                if ((!waitForInput && Time.time >= timeFadingInFinished + waitTime) || (waitForInput && Input.anyKey))
                {
                    status = FadeStatus.FadeOut;

                }
                break;
            case FadeStatus.FadeOut:
                alpha += -fadeSpeed * Time.deltaTime * 2;
                if (alpha <= 0.0f)
                {
                    if (trigger != null)
                    {
                        trigger();
                    }

                    status = FadeStatus.Paused;

                }
                break;

    void OnGUI()

        GUI.depth = guiDepth;

            status = FadeStatus.FadeWaiting;

            timeFadingInFinished = Time.time;

                loadingNextLevel = true;
                    //                  print(levelToLoadInt);
                   
                    SceneManager.LoadScene(levelToLoadInt);



                }
                    SceneManager.LoadScene(levelToLoadInt);


            }




}