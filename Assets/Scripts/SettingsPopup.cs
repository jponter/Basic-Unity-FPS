using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider speedSlider;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
    }

    public void OnSpeedValue(float speed)
    {
        Debug.Log("Speed: " + speed);
        PlayerPrefs.SetFloat("speed", speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    private void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }


    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }

}


   
