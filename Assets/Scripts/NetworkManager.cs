using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        switch (Network.peerType)//根据不同的情况选择下一步行动  
        {
            case NetworkPeerType.Disconnected:
                StartClient();//未连接状态下，启动客户端  
                break;
            case NetworkPeerType.Connecting:
                GUILayout.Label("Connecting");//连接状态下显示已连接  
                break;
            case NetworkPeerType.Server:
                break;
            case NetworkPeerType.Client:
                break;
        }

    }
    void StartClient()
    {
        if (GUILayout.Button("Connect"))//如果按下开启客户端按钮  
        {
            NetworkConnectionError e = Network.Connect("127.0.0.1", 2048);
            //获取连接服务器端的状况  
            Debug.Log("Error" + e);//输出调试日志  
        }
    }
}
