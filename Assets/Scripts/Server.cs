using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Server : MonoBehaviour {
    int Port = 2048;
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
                StartServer();//未连接状态下，开启服务器  
                break;
            case NetworkPeerType.Connecting:
                GUILayout.Label("Connecting");//连接状态下显示已连接  
                break;
            case NetworkPeerType.Server:
                onServer();//在服务器端口配置服务器  
                break;
            case NetworkPeerType.Client:
                break;
        }

    }

    void StartServer()
    {
        if (GUILayout.Button("create Server")) //如果按下开启服务器按钮  
        {
            NetworkConnectionError e = Network.InitializeServer(12, Port, false);
            //获取初始化服务器端的状况  
            Debug.Log("Error" + e); //输出调试日志  
        }
    }
    void onServer()
    {
        GUILayout.Box("Server is waiting for Client");

        int length = Network.connections.Length;//获取当前客户端的连接数量  
        for (int i = 0; i < length; i++)
        {
            GUILayout.Label("Client" + i);
            GUILayout.Label("Client IP" + Network.connections[i].ipAddress);
            GUILayout.Label("Client Port" + Network.connections[i].port);
        }

        if (GUILayout.Button("Disconnected"))
        {
            Network.Disconnect();//按下即断开网络  

        }

    }
}
