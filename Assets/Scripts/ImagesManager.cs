using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImagesManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private NetworkService _network;

    private Texture2D _webImage;

    public void Startup(NetworkService service)
    {
        Debug.Log("Images Manager Starting...");

        _network = service;
        status = ManagerStatus.Started;
    }

    public void GetWebImage(Action<Texture2D> callback)
    {
        if (_webImage == null)
        {
            Debug.Log("getting web image");
            StartCoroutine(_network.DownloadImage((Texture2D image) =>
            {
                _webImage = image;
                callback(_webImage);
            }));
                
                
        }
        else
        {
            callback(_webImage);
        }
    }
}
