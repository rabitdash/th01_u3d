using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour {
    private List<GameObject> cards = new List<GameObject>() ;
    public GameObject cardPrefab; //由外部给出
    public GameObject originalPosition;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < 10; i++)
        {
            var tmp = Instantiate(cardPrefab, originalPosition.transform.position + Vector3.right * 20f*i, Quaternion.identity);
            tmp.transform.SetParent(GameObject.Find("Canvas/Player0/HeapPos").transform);
            tmp.GetComponent<RectTransform>().localScale = Vector3.one * 0.3f;
            cards.Add(tmp);
 

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
