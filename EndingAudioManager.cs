using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip endingSound;

    public void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("bgmvol"); //bgm 볼륨 유지
        this.audioSource.clip = this.endingSound;
    }
}
