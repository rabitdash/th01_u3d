using DG.Tweening;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = System.Random;


public class CardManager : MonoBehaviour {
    #region 变量定义
    public static CardManager _instance;//单例
    public GameObject CardPrefab; //卡牌预制件
    public GameObject publicCardHeap; //出牌堆位置
    public GameObject publicDropHeap;//弃牌堆位置

    private const int nplayer = 2; //参与游戏的玩家数量
    private List<int> allCardIDs = new List<int>(); //所有卡牌ID列表
    private List<int> DrawCardIDs = new List<int>();//摸牌堆卡ID列表
    private List<int> DropCardIDs = new List<int>();//弃牌堆卡ID列表
    private List<CardInfo> allCardInfos = new List<CardInfo>(); //所有的CardInfo
    public List<Transform> CoveredTrans = new List<Transform>(); //所有Player的位置
    public List<Transform> FacedTrans = new List<Transform>(); //所有Player的位置

    private Dictionary<int, List<int>> _PlayerCards = new Dictionary<int, List<int>>(); //key:玩家编号 value:卡牌ID
    private Dictionary<int, string> IdOfCardName = new Dictionary<int, string>(); //key:卡牌ID value:卡牌名称
    private Dictionary<int, GameObject> _cardIdDictionary = new Dictionary<int, GameObject>(); //key:卡牌编号 value:卡牌GameObject对象

    enum State
    {
        Init = 0,//开局发牌
        Run  = 1,//正在游戏
    }

    private State currentState = State.Init; //初始化当前状态
    #endregion

    //生成玩家数组
    private void InitAllPlayers()
    {
        //Init all players transform
        for (var i = 0; i < nplayer; i++)
        {
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
            DrawCardIDs.Add(i); //摸牌堆
            allCardIDs.Add(i); //所有牌
            IdOfCardName.Add(key: i, value: allCardInfos[i].cardName); //将卡牌ID与对应的卡牌名存入字典
        }
    }

    //TODO 切换CardManager状态
    private void SwitchState()
    {
        if (currentState == State.Init)
        {
            currentState = State.Run;
        }
        else if (currentState == State.Run)
        {
            currentState = State.Init;
        }
    }

    //生成卡牌GameObject对象
    private void GenerateCardObject(int playerID, int cardID, Transform pos = null)//TODO 根据卡牌类型确定生成位置和大小 isInit是否是开局摸牌
    {
        //
        Transform tmp;
        if (pos == null)
        {
            tmp = CoveredTrans[playerID];
        }
        else
        {
            tmp = pos;
        }
        //

        var card = Instantiate(CardPrefab, tmp);//复制构造Card对象,位置在Player暗置区域
        card.GetComponent<Card>().InitCard(allCardInfos[cardID], cardID); //每张卡都有专属ID和CardInfo，利用(1)中生成的CardInfo对象生成Card对象的属性
        _cardIdDictionary.Add(cardID, card); //将卡牌ID与对应的卡牌GameObject对象存入字典
        card.name = string.Format("Card{0}", cardID); //GameObject对象名称
        var playerCardNum = _PlayerCards[playerID].Count; //现在玩家拥有的卡牌数量
        var offset = card.transform.position - card.transform.localPosition;//计算本地坐标与世界坐标系之差
        int cardInterval;//卡牌相对位置差
        Debug.Log(_PlayerCards[playerID].Count);

        switch (playerID) //TODO 根据卡牌类型决定生成位置
        {
            case 0:

                cardInterval = 20;
                if (currentState == State.Init)//如果是开局发牌
                {
                    card.transform.localPosition = new Vector3(30f, -10f, 0f); //设置卡牌位置
                    card.transform.DOLocalMove(new Vector3(30f + cardInterval * playerCardNum, -10f, 0f), 1f);
                }
                SetCardSize(card, cardSize:new Vector2(50f, 75f));//设置卡牌大小
                break;
            case 1:
                cardInterval = 20;
                if (currentState == State.Init)
                {
                    card.transform.localPosition = new Vector3();
                }
                SetCardSize(card, cardSize:new Vector2(30f, 45f));

                break;
        }

        if (currentState == State.Run)
        {
            RearrangePlayerCards(playerID);
        }
            Debug.Log(String.Format("Generate Player:{0} Card:{1}", playerID, cardID));
    }

    #region GenerateCardObject()调用子方法
    //重新安排卡牌
    public void RearrangePlayerCards(int playerID)
    {
        var cardInterval = 20;//TODO 间隔应间接计算
        //var cardNum = _PlayerCards.Count;//当前卡牌数量
        var i = 0;
        foreach (var cardID in _PlayerCards[playerID]) //每张卡都要移动
        {
            var card = _cardIdDictionary[cardID];
            switch (playerID)
            {
                case 0:
                    card.transform.DOLocalMoveX(30f + cardInterval * i, 1f);//TODO 不同的卡应放在不同位置
                    break;
                case 1:
                    //card.transform.DOLocalMoveX();
                    break;
                //TODO
            }

            i++;

        }
    }

    //设置卡牌大小
    private void SetCardSize(GameObject card, Vector2 cardSize)
    {
        var Images = card.GetComponentsInChildren<RectTransform>();
        foreach (var image in Images)
        {
            image.sizeDelta = cardSize;
        }
        card.GetComponent<RectTransform>().sizeDelta = cardSize;
    }



    #endregion

    //删除卡牌GameObject对象
    private void DestroyCardObject(int cardID)
    {
        GameObject.Destroy(_cardIdDictionary[cardID]);
    }

    #region Player类调用方法主体
    //获取某玩家手牌,在判断对方是否有某手牌时会用到
    private List<int> GetPlayerCards(int playerNum) {
        return _PlayerCards[playerNum]; 
    }

    //获取某玩家是否有某个手牌
    private bool PlayerHaveCard(int playerID, string cardName) //
    {
        var tmpCardIDs = GetPlayerCards(playerID);
        foreach (var cardID in tmpCardIDs)
        {
            if (IdOfCardName[cardID] == cardName) //如果在ID对应卡牌名的字典中找到
            {
                Debug.Log(String.Format("Player{0} have Card ID={1}", playerID, cardID));
                return true;//有,不返回有多少张
            }
        }
        return false;
    }

    //将某手牌从摸牌堆移至玩家的手牌堆
    public bool AddCardTo(int playerID, string cardName = null) //注意不要用超了，每次发牌时要检查摸牌堆里是否有牌，还要检查玩家的牌堆是否用超，超了要弃卡
    {
        //TODO 超出数量限制，弃卡
        //TODO 将动画分离，函数ShowCard()
        if (DrawCardIDs.Count == 0)
        {
            Debug.Log("DrawCardHeap is empty");
            return false; //摸牌堆里没有卡，直接返回
        }

        if (cardName == null) //未指定卡名则随机生成
        {
            var cardID = DrawCardIDs[0];
            GenerateCardObject(playerID, cardID);
            DrawCardIDs.Remove(cardID);
            GetPlayerCards(playerNum: playerID).Add(cardID);
            Debug.Log(String.Format("Randomly add Card {0}", IdOfCardName[cardID]));
            return true;
        }
        else //已指定卡名
        {

            foreach (var cardID in DrawCardIDs)
            {
                if (IdOfCardName[cardID] == cardName) //如果在ID对应卡牌名的字典中找到
                {
                    GenerateCardObject(playerID, cardID);
                    DrawCardIDs.Remove(cardID);
                    GetPlayerCards(playerID).Add(cardID);
                    Debug.Log(String.Format("Specific add Card {0}", IdOfCardName[cardID]));
                    return true; //增加卡牌
                }
            }
        }
        return false;
    }

    public void DropCardFrom(int playerID, string cardName = null)
    {
        if (cardName == null)
        {
            var cardID = _PlayerCards[playerID][new Random(Time.time.GetHashCode()).Next(0, _PlayerCards[playerID].Count)];//TODO 随机
            DropCardIDs.Add(cardID);
            _PlayerCards[playerID].Remove(cardID);
            DestroyCardObject(cardID);
            _cardIdDictionary.Remove(cardID);
            RearrangePlayerCards(playerID);
        }
        else
        {
            if (_PlayerCards[playerID].Count > 0)
            {
                foreach (var cardID in _PlayerCards[playerID])
                {
                    if (IdOfCardName[cardID] != cardName) continue;
                    DropCardIDs.Add(cardID);//弃牌堆加卡
                    _PlayerCards[playerID].Remove(cardID);//从玩家手中移除卡
                    
                    DestroyCardObject(cardID);//去除卡牌对象
                    _cardIdDictionary.Remove(cardID);
                    RearrangePlayerCards(0);//整理卡牌
                    Debug.Log("Randomly drop Player{0}'s card");
                    return;//结束
                }
            }

            else
            {
                Debug.Log(String.Format("Player{0} has no card to drop", playerID));
            }
        }
        
    }

    public void GiveCardTo(int fromPlayerID, int toPlayerID, int cardID = -1)//cardID需要特别获取,否则随机丢卡 TODO
    {
        if (cardID == -1)
        {
            cardID = _PlayerCards[fromPlayerID][new Random(Time.time.GetHashCode()).Next(0, _PlayerCards[fromPlayerID].Count)];//随机
        }
        _PlayerCards[fromPlayerID].Remove(cardID);
        DestroyCardObject(0);
        _PlayerCards[toPlayerID].Add(cardID);
        GenerateCardObject(toPlayerID, cardID);
    }
    #endregion

    private void ShuffleCards()//对摸牌堆洗牌
    {
        DrawCardIDs = GetRandomList<int>(DrawCardIDs);
    }
    
    //获取随机列表
    private static List<T> GetRandomList<T>(List<T> inputList)
    {
        //Copy to a array
        T[] copyArray = new T[inputList.Count];
        inputList.CopyTo(copyArray);

        //Add range
        List<T> copyList = new List<T>();
        copyList.AddRange(copyArray);

        //Set outputList and random
        List<T> outputList = new List<T>();
        Random rd = new Random(DateTime.Now.Millisecond);

        while (copyList.Count > 0)
        {
            //Select an index and item
            int rdIndex = rd.Next(0, copyList.Count - 1);
            T remove = copyList[rdIndex];

            //remove it from copyList and add it to output
            copyList.Remove(remove);
            outputList.Add(remove);
        }
        return outputList;
    }

    public void NewTurn()//TODO 需要再修改
    {
        for (var playerID = 0; playerID < nplayer; playerID++ )
        {
                foreach (var cardID in _PlayerCards[playerID])
                {
                    DestroyCardObject(cardID);
                }
            _PlayerCards[playerID].Clear();
        }
        DrawCardIDs.Clear();
        DropCardIDs.Clear();
        _PlayerCards.Clear();
        allCardInfos.Clear();
        _cardIdDictionary.Clear();
        allCardIDs.Clear();
        IdOfCardName.Clear();
        InitAllPlayers();
        InitAllCardInfos();
        ShuffleCards();
        //currentState = State.Run;
    }

    // Use this for initialization
    private void Awake () {
        _instance = this; //单例
        InitAllPlayers();
        InitAllCardInfos();
        ShuffleCards();
        test();

    }

    void Start()
    {
    }

    //功能测试
    private void test()
    {
        Debug.Log("---");
        Debug.Log("---");
        Debug.Log("---"); 
        Debug.Log(DrawCardIDs.Count);
        foreach (var cardID in DrawCardIDs)
        {
            Debug.Log(IdOfCardName[cardID]);
        }
        /*AddCardTo(0);
        AddCardTo(0);
        AddCardTo(0);
        AddCardTo(1);
        AddCardTo(1);
        AddCardTo(0, "shiliuyexiaoye");
        AddCardTo(0, "八卦炉");
        AddCardTo(1, "帕秋莉");
        AddCardTo(1, "remiliya");
        PlayerHaveCard(0, "Card");
        PlayerHaveCard(1, "八卦炉");
        AddCardTo(0);*/
    }
	// Update is called once per frame

    private void Update () {
		
	}
}
