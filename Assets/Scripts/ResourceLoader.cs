using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tools
{
    public class ResourceLoader
    {
        public static List<CardInfo> LoadCardInfos()
        {
            TextAsset ts = Resources.Load("Cards/CardInfo", typeof(TextAsset)) as TextAsset;
            string json = ts.text;
            List<CardInfo> CardInfos = JsonConvert.DeserializeObject<List<CardInfo>>(json);
            return CardInfos;
        }

        public static Sprite LoadCardImage(CardInfo cardInfo)
        {
            
            return Resources.Load(String.Format("Cards/Images/{0}", cardInfo.CardID), typeof(Sprite)) as Sprite;
        }

        public static CardSkill LoadCardSkill()
        {
            return  new CardSkill();
        }

    }

}

