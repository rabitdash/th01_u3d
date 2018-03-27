using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMove(new Vector3(10, 10, 10), 5, true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
