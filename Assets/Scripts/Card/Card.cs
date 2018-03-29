using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    //是一个Unity中的游戏对象类
    private Image image;        //牌的图片
    private CardInfo cardInfo;  //卡牌信息
    private bool isSelected = false;    //是否选中
    GameObject go;
    void Awake()
    {
        image = GetComponent<Image>();
        go = GameObject.Find("Canvas/Player0/HeapPos");

    }
    public void InitImage(CardInfo cardInfo)
    {
        this.cardInfo = cardInfo;
        image.sprite = Resources.Load("Images/Cards/" + cardInfo.cardName, typeof(Sprite)) as Sprite;
    }

    #region 鼠标事件函数,直接执行
    //玩家鼠标移到卡牌上
    public void OnMouseEnter()
    {
        var trans = go.transform;
        if (!DOTween.IsTweening(transform))
        {

            transform.DOMoveY(trans.position.y + 10/0f, 0.01f);
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
    //玩家鼠标拖动卡牌
    //cardInfo.isSelected = true;
    #endregion
}

