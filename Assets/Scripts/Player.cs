using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected List<CardInfo> cardInfos = new List<CardInfo>();  //个人所持卡牌

    private Text cardCoutText;

    void Start()
    {
        cardCoutText = transform.Find("HeapPos/Text").GetComponent<Text>();
    }
    /// <summary>
    /// 增加一张卡牌
    /// </summary>
    /// <param name="cardName"></param>
    public void AddCard(string cardName)
    {
        cardInfos.Add(new CardInfo(cardName));
        cardCoutText.text = cardInfos.Count.ToString();
    }
    /// <summary>
    /// 清空所有卡片
    /// </summary>
    public void DropCards()
    {
        cardInfos.Clear();
    }

    protected void Sort()
    {
        cardInfos.Sort();
        cardInfos.Reverse();
    }
}
