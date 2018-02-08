using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TextShow : MonoBehaviour
{
    private Text poemText1;
    private Text poemText2;
    private Text poemText3;
    private Text poemText4;
    private Text poemText5;
    private Text poemText6;
    private Text poemText7;
    private Text poemText8;
    private bool isTextOver = false;
    // Use this for initialization
    void Start()
    {
        poemText1 = transform.Find("poem1").GetComponent<Text>();
        poemText2 = transform.Find("poem2").GetComponent<Text>();
        poemText3 = transform.Find("poem3").GetComponent<Text>();
        poemText4 = transform.Find("poem4").GetComponent<Text>();
        poemText5 = transform.Find("poem5").GetComponent<Text>();
        poemText6 = transform.Find("poem6").GetComponent<Text>();
        poemText7 = transform.Find("poem7").GetComponent<Text>();
        poemText8 = transform.Find("poem8").GetComponent<Text>();
        StartCoroutine(ShowPoem());
      
    }
    private void Update()
    {
      
    }
    //这里我们使用携程来进行我们诗句的显示
    //这个展示诗的时候我们也要代码控制它的alpha值
    IEnumerator ShowPoem()
    {
        //这是每句诗的显示
        poemText1.DOText("菡萏香销翠叶残", 2f);
        poemText1.DOFade(1, 2f);

        yield return new WaitForSeconds(1.55f);
        
        poemText2.DOText("西风愁起绿波间", 2f);
        poemText2.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);
        
        poemText3.DOText("还与韶光共憔悴", 2f);
        poemText3.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);
       
        poemText4.DOText("不堪看", 0.5f);
        poemText4.DOFade(1, 2f);
        yield return new WaitForSeconds(0.5f);

        poemText5.DOText("细雨梦回鸡塞远", 2f);
        poemText5.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);

        poemText6.DOText("小楼吹彻玉笙寒", 2f);
        poemText6.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);

        poemText7.DOText("多少泪珠何限恨", 2);
        poemText7.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);

        poemText8.DOText("倚栏干", 0.5f);
        poemText8.DOFade(1, 2f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }
}
