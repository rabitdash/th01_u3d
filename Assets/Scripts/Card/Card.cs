using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    //是一个Unity中的游戏对象类
    private Image faceImage;        //牌的图片
    public CardInfo cardInfo;  //卡牌信息
    private TextAsset description; //卡牌描述
    private Text textBox;

    private CanvasRenderer imageRenderer;

    GameObject go;
    private Transform self;

    void Awake()
    {

        self = transform.Find("Face");
        faceImage = self.GetComponent<Image>();
        StartCoroutine(Timer());

        imageRenderer = self.GetComponent<CanvasRenderer>();
        imageRenderer.SetAlpha(1f);

    }

    void Update()
    {

}

    public void InitCard(CardInfo cardInfo,int cardId)
    {
        this.cardInfo = cardInfo;
        cardInfo.cardID = cardId;
        InitImage();
        InitCardSkill();
        InitDescription();
    }

    private void InitImage()
    {
        Debug.Log(cardInfo._cardFileName);
        faceImage.sprite = Resources.Load("Cards/Images/" + cardInfo._cardFileName, typeof(Sprite)) as Sprite;
        
    }

    private void InitDescription()//TODO
    {
        description = Resources.Load("Cards/Descriptions/" + cardInfo._cardFileName, typeof(TextAsset)) as TextAsset;
        Debug.Log(description.text);
    }

    private void InitCardSkill() //初始化卡牌技能
    {
        //TODO
    }

    public void ExecuteCardSkill(int toPlayerNum) //执行卡牌技能
    {
        //TODO
    }

    IEnumerator Timer() //Debug
    {
        while (true)
        {
            Debug.Log("TimerUp");
            yield return new WaitForSeconds(3);
        }

    }

    #region 鼠标事件函数,直接执行
    //玩家鼠标移到卡牌上
    public void OnMouseEnter()
    {
        var trans = go.transform;
        if (!DOTween.IsTweening(transform))
        {

            transform.DOMoveY(trans.position.y + 100f, 0.01f);
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.01f);
        }
        Debug.Log("OnMouseEnter");
    }
    
    //玩家鼠标离开卡牌
    public void OnMouseExit() 
    {
        var trans = go.transform;
        if (!DOTween.IsTweening(transform))
        {
            transform.DOMoveY(trans.position.y, 0.01f);
            transform.DOScale(new Vector3(0.3f, 0.3f, 0.3f), 0.01f);
        }
        Debug.Log("OnMouseExit");
    }
    //玩家鼠标点击卡牌
    public void OnMouseDown()
    {
        this.cardInfo.isSelected = !this.cardInfo.isSelected;//卡牌初始化时默认isSelected=false

    }
    #endregion
}

