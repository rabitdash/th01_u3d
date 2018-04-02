using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

[Serializable] //可序列化
public class CardManager : MonoBehaviour {
    #region 变量定义
    public static CardManager _instance;//单例
    public GameObject CardPrefab; //卡牌预制件
    public GameObject publicCardHeap; //出牌堆位置
    public GameObject publicDropHeap;//弃牌堆位置
    public int nplayer; //参与游戏的玩家数量
    private List<int> allCardIDs = new List<int>(); //卡牌ID列表
    private List<int> DrawCardIDs = new List<int>();
    private List<int> DropCardIDs = new List<int>();

    private Random randomInt;
    //TODO 摸牌堆卡ID列表
    //TODO 弃牌堆卡ID列表
    //TODO 所有卡ID列表
    private List<CardInfo> allCardInfos = new List<CardInfo>(); //所有的CardInfo
    private List<Transform> allPlayersTransform = new List<Transform>(); //所有Player的位置
    private Dictionary<int, List<int>> _PlayerCards = new Dictionary<int, List<int>>(); //key:玩家编号 value:卡牌ID
    private Dictionary<int, string> IdOfCardName = new Dictionary<int, string>(); //key:卡牌ID value:卡牌名称
    private Dictionary<int, GameObject> _cardIdDictionary = new Dictionary<int, GameObject>(); //key:卡牌编号 value:卡牌GameObject对象
    #endregion

    //生成玩家数组
    private void InitAllPlayers()
    {
        //Init all players transform
        for (var i = 0; i < nplayer; i++)
        {
            allPlayersTransform.Add(GameObject.Find(String.Format("Canvas/Players/Player{0}/cardArea", i)).GetComponent<Transform>());//查找所有玩家位置
            _PlayerCards.Add(i, new List<int>());//初始化字典
        }

    }

    //生成CardInfo对象数组
    private void InitAllCardInfos()
    {
        var fullPath = "Assets/Resources/Cards/Images/";
        Debug.Log("Card images loaded");
        var allCardNames = new List<string>();
        if(Directory.Exists(fullPath))
        {
            var folder = new DirectoryInfo(fullPath);
            foreach (var file in folder.GetFiles("*.png"))//需要是png文件
            {
                Debug.Log(file.Name);
                allCardNames.Add(file.Name.Split('.')[0]); //将卡牌文件名加入列表
            }
                
        }

        foreach (var cardFileName in allCardNames) //遍历卡牌文件名数组
        {
            allCardInfos.Add(new CardInfo(cardFileName)); //调用CardInfo构造函数，将CardInfo对象加入列表(1)
        }

        for (var i = 0; i < allCardInfos.Count; i++)
        {
            DrawCardIDs.Add(i);//摸牌堆
            allCardIDs.Add(i);//所有牌
            IdOfCardName.Add(key: i, value: allCardInfos[i].cardName); //将卡牌ID与对应的卡牌名存入字典
            i++;
        }
    }

    //生成卡牌GameObject对象
    private void GenerateCardObject(int playerID, int cardID)//TODO IEnumrator 根据卡牌类型确定生成位置
    {
            var card = Instantiate(CardPrefab, allPlayersTransform[playerID]);//复制构造Card对象,位置在Player
            card.GetComponent<Card>().InitCard(allCardInfos[cardID], cardID); //每张卡都有专属ID和CardInfo，利用(1)中生成的CardInfo对象生成Card对象的属性
            _cardIdDictionary.Add(cardID, card); //将卡牌ID与对应的卡牌GameObject对象存入字典
            card.name = string.Format("Card{0}", cardID);
            card.transform.localPosition = new Vector2(0f, 0f);
            card.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 75f);
    }

    //获取某玩家手牌,在判断对方是否有某手牌时会用到
    private List<int> GetPlayerCards(int playerNum) {
        return _PlayerCards[playerNum]; 
    }

    //获取某玩家是否有某个手牌
    private bool ifPlayerHaveCard(int playerID, string cardName) //
    {
        var tmpCardIDs = GetPlayerCards(playerID);
        foreach (var cardID in tmpCardIDs)
        {
            if (IdOfCardName[cardID] == cardName) //如果在ID对应卡牌名的字典中找到
            {
                Debug.Log(String.Format("Player{0} have Card ID={1}", playerID, cardID));
                return true;//有,不管有多少张
            }
        }

        return false; //TODO
    }

    //将某手牌移至玩家的手牌堆 TODO debug
    public bool AddCardTo(int playerID, string cardName = "") //注意不要用超了，每次发牌时要检查摸牌堆里是否有牌
    {
        if (DrawCardIDs.Count == 0)
        {
            return false; //摸牌堆里没有卡，直接返回
        }
        if (cardName == "") //未指定卡名则随机生成
        {
            var randInt = randomInt.Next(0, DrawCardIDs.Count);
            var cardID = DrawCardIDs[randInt];
            GenerateCardObject(playerID, cardID);
            DrawCardIDs.Remove(cardID);
            GetPlayerCards(playerNum:playerID).Add(cardID);
            return true;
        }
        else
        {

            foreach (var cardID in DrawCardIDs)
            {
                if (IdOfCardName[cardID] == cardName) //如果在ID对应卡牌名的字典中找到
                {
                    GenerateCardObject(playerID, cardID);
                    DrawCardIDs.Remove(cardID); //这里是移除元素
                    GetPlayerCards(playerID).Add(cardID);
                    Debug.Log("shit!");
                    return true; //增加卡牌
                }
            }
        }

        return false;


        //TODO 改为IEnumerator 调用GenerateCardObjects
    }



    // Use this for initialization
    private void Awake () {
        randomInt = new Random();
        _instance = this; //单例
        InitAllPlayers();
        InitAllCardInfos();
        test();

    }

    //功能测试
    private void test()
    {
        //AddCardTo(0, "Card");
        //AddCardTo(0, "Card");
        //AddCardTo(0);
        //AddCardTo(0);
        AddCardTo(1, "八卦炉");
        AddCardTo(1, "shiliuyexiaoye");
        AddCardTo(1, "remiliyasikaleite");
        //ifPlayerHaveCard(0, "Card");
    }
	// Update is called once per frame
    private void Update () {
		
	}
}
