using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetSync : NetworkBehaviour
{
    public static NetSync Instance;

    // Use this for initialization
    void Awake ()
    {
        Instance = this;
    }

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
	}

    
    [Command]
    private void CmdAddCard(int id)
    {
        CardManager.Instance.AddCardTo(1, id);
    }

    //Overload
    [Command]
    private void CmdAddCard(string name)
    {
        CardManager.Instance.DropCardFrom(1, name);
    }

    [Command]
    private void CmdDropCard(int id)
    {
        CardManager.Instance.DropCardFrom(1, id);
    }

    //Overload
    [Command]
    private void CmdDropCard(string name)
    {
        CardManager.Instance.DropCardFrom(1, name);
    }

    [ClientRpc]
    private void RpcAddCard(int id)
    {
        CardManager.Instance.AddCardTo(1, id);
    }

    //Overload
    [ClientRpc]
    private void RpcAddCard(string name)
    {
        CardManager.Instance.AddCardTo(1, name);
    }

    [ClientRpc]
    private void RpcDropCard(int id)
    {
        CardManager.Instance.DropCardFrom(1, id);
    }

    //Overload
    [ClientRpc]
    private void RpcDropCard(string name)
    {
        CardManager.Instance.DropCardFrom(1, name);
    }

    private void RemoteAddCard(int id)
    {
        if (isServer)//Server
        {
            RpcAddCard(id);
        }
        else if (isClient)//Client
        {
            CmdAddCard(id);
        }
    }

    private void RemoteDropCard(int id)
    {
        if (isServer)//Server
        {
            RpcDropCard(id);
        }
        else if (isClient)//Client
        {
            CmdDropCard(id);
        }
    }

    public void AddCard(int id)
    {
        CardManager.Instance.AddCardTo(0, id);
        RemoteAddCard(id);
    }

    //Overload
    public void AddCard(string name)
    {
        var id = CardManager.Instance.AddCardTo(0, name);
        RemoteAddCard(id);
    }

    public void DropCard(int id)
    {
        CardManager.Instance.DropCardFrom(0, id);
        RemoteDropCard(id);
    }

    //Overload
    public void DropCard(string name)
    {
        var id = CardManager.Instance.DropCardFrom(0, name);
        RemoteDropCard(id);
    }

}
