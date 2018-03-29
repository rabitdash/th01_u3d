using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour {
    #region 变量定义
    List<string> cardNames;
    static CardManager _instance;//单例
    #endregion
    //读取所有卡牌名
    public List<string> GetCardNames()
    {
        string fullPath = "Assets/Resources/Images/";
        List<string> allCardNames = new List<string>();
        if(Directory.Exists(fullPath))
        {
            DirectoryInfo folder = new DirectoryInfo(fullPath);
            foreach(FileInfo file in folder.GetFiles("*.png"))
            {
                allCardNames.Add(file.Name);
            }
        }
        return allCardNames;
    }
    //生成卡牌

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
