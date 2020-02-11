using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public float cloudValue { get; private set; }

    private NetworkService _network;

public void Startup(NetworkService service)
    {
        Debug.Log("Weather Manager Starting...");

        _network = service;
        StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));

        status = ManagerStatus.Initializing;

        
    }

    public void OnXMLDataLoaded(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(data);
        XmlNode root = doc.DocumentElement;

        XmlNode node = root.SelectSingleNode("clouds");
        string value = node.Attributes["value"].Value;
        cloudValue = Convert.ToInt32(value) / 100f;
        Debug.Log("Value: " + cloudValue);

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
        status = ManagerStatus.Started;
    }
}
