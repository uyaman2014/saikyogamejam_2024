using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using UnityEngine;

public class NetworkManager : Singleton<NetworkManager>
{
    private WebSocket ws;
    private string room = "testRoom";

    public NetworkManager()
    {
        ws = new WebSocket("ws://localhost:3000/");
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Data: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };

        ws.Connect();

    }

    public void CloseConnection()
    {
        ws.Close();
    }

    public void SendClickedCount(int ClickCount)
    {
        ws.SendAsync("Count:" + ClickCount.ToString(), (b) => { });
    }

    public void CreateRoom()
    {
        ws.SendAsync("CreateRoom:" + room, (b) => { });
    }
}
