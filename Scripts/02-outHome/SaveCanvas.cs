using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SaveCanvas : MonoBehaviour
{
    public bool dontDestroyOnLoad = true;
    public bool DontCreateNewWhenBackToThisScene = true;
    public static SaveCanvas Instance = null;
    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
        if (this.dontDestroyOnLoad)
            GameObject.DontDestroyOnLoad(this);
    }
}
