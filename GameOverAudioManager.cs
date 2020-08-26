using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gameOverSound;

    public void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("bgmvol"); //bgm 볼륨 유지
        this.audioSource.clip = this.gameOverSound;
    }
}
