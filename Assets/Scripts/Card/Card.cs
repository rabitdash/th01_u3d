using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
    {
        private Image image;        //牌的图片
        private CardInfo cardInfo;  //卡牌信息
        private bool isSelected;    //是否选中

        void Awake()
        {
            image = GetComponent<Image>();
        }

        /// <summary>
        /// 初始化图片
        /// </summary>
        /// <param name="cardInfo"></param>
        public void InitImage(CardInfo cardInfo)
        {
            this.cardInfo = cardInfo;
            image.sprite = Resources.Load("Images/Cards/" + cardInfo.cardName, typeof(Sprite)) as Sprite;
        }
        /// <summary>
        /// 设置选择状态
        /// </summary>
        public void SetSelectState()
        {
            if (isSelected)
            {
                iTween.MoveTo(gameObject, transform.position - Vector3.up * 10f, 1f);
            }
            else
            {
                iTween.MoveTo(gameObject, transform.position + Vector3.up * 10f, 1f);
            }

            isSelected = !isSelected;
        }
    }
