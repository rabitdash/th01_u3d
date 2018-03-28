using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected List<CardInfo> cardInfos = new List<CardInfo>();  //个人所持卡牌
    private Transform smallCardPos;     //出牌的原始位置
    private List<GameObject> smallCards = new List<GameObject>();
    public GameObject prefabSmall;

    private Text cardCoutText;

    void Start()
    {
        cardCoutText = transform.Find("HeapPos").GetComponent<Text>();
        smallCardPos = transform.Find("smallCardPos");

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
    public void ForFollow()
    {

        //选择的牌，添加到出牌区域
        var selectedCards = cardInfos.Where(s => s.isSelected).ToList(); //
        var offset = 5;
        for (int i = 0; i < selectedCards.Count(); i++)
        {
            var card = Instantiate(prefabSmall, smallCardPos.position + Vector3.right * offset * i, Quaternion.identity, smallCardPos.transform);
            card.GetComponent<RectTransform>().localScale = Vector3.one * 0.3f;
            card.GetComponent<Image>().sprite = Resources.Load("Images/Cards/" + selectedCards[i].cardName, typeof(Sprite)) as Sprite;
            card.transform.SetAsLastSibling();

            smallCards.Add(card);
        }
        cardInfos = cardInfos.Where(s => !s.isSelected).ToList();

        //CardManager._instance.ForFollow();
        //CardManager._instance.currentCardInfos = selectedCards;

        //isMyTerm = false;
    }

    protected void Sort()
    {
        cardInfos.Sort();
        cardInfos.Reverse();
    }
}
