using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnim : MonoBehaviour
{
    public int animvalue;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(Random.Range(1, animvalue+1).ToString());
        anim.speed = Random.Range(0.5f, 1f);
    }

   
    }

