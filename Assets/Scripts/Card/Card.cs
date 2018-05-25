using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[Serializable]
//是一个Unity中的游戏对象类
public class Card : MonoBehaviour
{
    private Image FaceImage;        //卡面图片
    //private Image coverImage; 
    public CardInfo cardInfo;  //卡牌信息
    private TextAsset description; //卡牌描述
    private Text textBox; //Debug
    private static int SiblingIndex;

    public void InitCard(CardInfo cardInfo) //初始化卡牌对象数据
    {
        this.cardInfo = cardInfo;
        
        //HeapTransform = GameObject.Find(String.Format("Player{0}/cardArea", cardInfo.playerID)).GetComponent<Transform>();
        Debug.Log(String.Format("CardID:{0}, playerID:{1}", cardInfo.CardID, this.cardInfo.playerID));
        FaceImage = transform.Find("Face").GetComponent<Image>();
        FaceImage.sprite = Tools.ResourceLoader.LoadCardImage(cardInfo);
    }

    void Awake()
    {
        

    }
    #region InitCard()所需函数
    #endregion

    IEnumerator Timer(int n) //TODO Debug
    {
            Debug.Log("TimerUp");
        yield return new WaitForSeconds(n);

    }

    #region 鼠标事件函数,直接执行
 //玩家鼠标移到卡牌上
    public void OnMouseEnter()//TODO
    {
        //ShowCard(cardinfo) //显示卡牌
        /*if (this.cardInfo.playerID == 0)
        {
            transform.SetSiblingIndex(1000);//置顶
            if (!DOTween.IsTweening(transform, true))
            {
                Sequence mySequence = DOTween.Sequence();
                mySequence.Append(transform.DOScale(new Vector3(2f, 2f, 2f), 0.01f));
                mySequence.Append(transform.DOMoveY(HeapTransform.position.y + 140f, 0.01f));
                
                

            }
        }*/
        //TODO 现在只是假设Player0的情况 对手暗置牌应该不可见
        GameObject.Find("CardShow").GetComponent<Image>().color = new Color(1,1,1,1);
        GameObject.Find("CardShow").GetComponent<Image>().sprite = Tools.ResourceLoader.LoadCardImage(cardInfo);
        //

        //Debug.Log("OnMouseEnter");
    }
    
    //玩家鼠标离开卡牌
    public void OnMouseExit() 
    {
        //        if (!DOTween.IsTweening(transform, true))
        //        { //TODO
        //            Sequence mySequence = DOTween.Sequence();
        //            mySequence.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.01f));
        //            mySequence.Append(transform.DOMoveY(HeapTransform.position.y - 10f, 0.01f));
        //
        //        }
        //        transform.SetSiblingIndex(cardInfo.SiblingIndex); //不置顶
        //        Debug.Log(cardInfo.SiblingIndex);
        //
        GameObject.Find("CardShow").GetComponent<Image>().color = new Color(0, 0, 0, 0);
        //Debug.Log("OnMouseExit");
    }

    //玩家鼠标点击卡牌

    public void OnMouseClick()
    {
        this.cardInfo.isSelected = !this.cardInfo.isSelected;//卡牌初始化时默认isSelected=false


        //transform.Find("flag1").gameObject.SetActive(this.cardInfo.isCovered);
        CardManager.Instance.RearrangePlayerCards(cardInfo.playerID); //TODO

    }

    public void OnMouseDoubleClick()
    {
        this.cardInfo.isCovered = !this.cardInfo.isCovered;
    }
    #endregion
}

