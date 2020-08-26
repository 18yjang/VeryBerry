using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAudioManager : MonoBehaviour
{
    //public static MainMenuAudioManager Instance; //싱글턴

    public AudioSource audioSource;

    public Slider bgmVolume; //bgm 슬라이더
    public Slider SFXVolume; //sfx 슬라이더

    private float bgmVol = 1.0f; //bgm 슬라이더 값을 유지하기 위한 변수
    private float sfxVol = 1.0f; //sfx 슬라이더 값을 유지하기 위한 변수

    public void Start()
    {
        bgmVol = PlayerPrefs.GetFloat("bgmvol", 1.0f); //"bgmvol"이 비어있을 경우 1.0
        bgmVolume.value = bgmVol;
        audioSource.volume = bgmVolume.value;

        sfxVol = PlayerPrefs.GetFloat("sfxvol", 1.0f);
        SFXVolume.value = sfxVol;
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        audioSource.volume = bgmVolume.value; //슬라이더 값을 오디오소스의 volume에 대입

        bgmVol = bgmVolume.value;
        sfxVol = SFXVolume.value;
        PlayerPrefs.SetFloat("bgmvol", bgmVol); //"bgmvol"이라는 키에 bgmVol 저장
        PlayerPrefs.SetFloat("sfxvol", sfxVol);
    }

    /*
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); //게임 오브젝트 중복 방지(배경음악 중복 플레이 방지)
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); //게임 오브젝트 유지
    }
    */
}