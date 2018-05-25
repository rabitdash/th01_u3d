using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetSync : NetworkBehaviour
{
    private static Player Player1;
    public static NetSync Instance;

    // Use this for initialization
    void Awake ()
    {
        Instance = this;
    }

    void Start()
    {
        Player1 = BattleController.Player1;
    }
	
	// Update is called once per frame
	void Update () {
	}

    
    [Command]
    public void CmdAddCard(int id)
    {
        Player1.AddCard(id);
    }

    [ClientRpc]
    public void RpcAddCard(int id)
    {
        Player1.AddCard(id);
    }

    public void AddCard(int id)
    {
        if (isServer)//Host
        {
            RpcAddCard(id);
        }
        else if(isClient)//Client
        {
            CmdAddCard(id);
        }
    }

}
