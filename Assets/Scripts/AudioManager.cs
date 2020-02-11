using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{

    public ManagerStatus status { get; private set; }

    private NetworkService _network;

    //10.4 goes here
    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    public void Startup(NetworkService service)
    {
        _network = service;

        soundVolume = 1.0f;

        //init music sources here 10.10

        status = ManagerStatus.Started;

    }


}
   
