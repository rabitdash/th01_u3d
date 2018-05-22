using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardInfo : IComparable
{
    //负责卡牌非U3D对象信息，实现比较接口
    //public string _cardFileName; //卡牌文件名
    public string CardName; //卡牌名
    public int CardID; //卡牌ID，卡牌唯一
    public int playerID; //这张卡目前是谁持有
    public bool isSelected; //是否被选中
    public bool isCovered = true; //是否被暗置
    public bool isShow = true; //是否能看到卡面
    public int SiblingIndex; //外部设置
    private bool isDrop; //是否被弃牌
    private bool isUsed; //是否已发动技能
    private CardTypes cardType; //牌的类型
    public string Description;

    enum CardTypes //卡牌类型
    {
        Artifact  = 1, //神器卡
        Character = 2, //人物卡
        Event     = 3, //事件卡

    }



    public CardInfo(int CardID, string CardType, string CardName, string Description) //初始化构造函数
    {
        this.isSelected = false; //默认未选择
        this.CardName = CardName;//获取卡牌名称
        this.CardID = CardID;
        this.Description = Description;
        //Debug.Log(String.Format("CardName:{0}", CardName));

        switch (CardType)
        {
            case "神器":
                cardType = CardTypes.Artifact;
                //Debug.Log("CardTypes.Artifact");
                break;
            case "人物":
                cardType = CardTypes.Character;
                //Debug.Log("CardTypes.Character");
                break;
            case "事件":
                cardType = CardTypes.Event;
                //Debug.Log("CardTypes.Event");
                break;
            default:
                return;
        }
    }

    int IComparable.CompareTo(object obj) //比较各种卡的效果顺序
    {
        CardInfo other = obj as CardInfo;
        if(other == null)
        {
            throw new Exception("Invalid comparation");
        }
        //当前卡比比较的卡优先，返回1
        //可能出bug
        if((int)cardType < (int)other.cardType)
        {
            return 1;
        }
        if((int)cardType > (int)other.cardType)
        {
            return -1;
        }
        if(cardType == other.cardType)
        {
            return 0;
        }
        throw new NotImplementedException();
    }
}
