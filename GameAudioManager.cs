using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioManager : MonoBehaviour
{
    public AudioSource BGMAudioSource;
    public AudioSource SFXAudioSource;
    public AudioClip eatSound;
    public GameObject berryManager;

    public Slider bgmVolume; //bgm 슬라이더
    public Slider SFXVolume; //sfx 슬라이더

    private float bgmVol = 1.0f; //bgm 슬라이더 값을 유지하기 위한 변수
    private float sfxVol = 1.0f; //sfx 슬라이더 값을 유지하기 위한 변수

    public void Start()
    {
        BGMAudioSource.volume = PlayerPrefs.GetFloat("bgmvol"); //bgm 볼륨 값 적용
        SFXAudioSource.volume = PlayerPrefs.GetFloat("sfxvol"); //sfx 볼륨 값 적용
        this.SFXAudioSource.clip = this.eatSound;
        this.SFXAudioSource.loop = false; //sfx 반복 재생 금지

        bgmVol = PlayerPrefs.GetFloat("bgmvol", 1.0f); //"bgmvol"이 비어있을 경우 1.0
        bgmVolume.value = bgmVol;
        BGMAudioSource.volume = bgmVolume.value;

        sfxVol = PlayerPrefs.GetFloat("sfxvol", 1.0f);
        SFXVolume.value = sfxVol;
    }

    void Update()
    {
        SoundSlider();

        if (GameObject.Find("GameManager").GetComponent<GameManager>().isFever) //피버타임일 때
        {
            BGMAudioSource.volume = 0;

            if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("GameManager").GetComponent<GameManager>().isDelay == false)
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if (berryManager.GetComponent<BerryImage>().arrow[i] != null && berryManager.GetComponent<BerryImage>().berry[i].CompareTag("Berry") &&
                        (berryManager.GetComponent<BerryImage>().currentTime[i] / berryManager.GetComponent<BerryImage>().nextTime[i] >= 0.7f)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }
            }
        }
        else //피버타임 아닐 때
        {
            BGMAudioSource.volume = PlayerPrefs.GetFloat("bgmvol");

            if (Input.GetKeyDown(KeyCode.Q))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("Q")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("W")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("E")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.R))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("R")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.A))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("A")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.S))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("S")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.D))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("D")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
            else if (Input.GetKeyDown(KeyCode.F))    // 키입력 확인 
            {
                for (int i = 0; i < berryManager.GetComponent<BerryImage>().berryCount; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[i] != null) && (berryManager.GetComponent<BerryImage>().arrow[i].CompareTag("F")) && (berryManager.GetComponent<BerryImage>().arrow[i].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        this.SFXAudioSource.Play(); //sfx 플레이
                        break;
                    }
                }

            }
        }
    }
    public void SoundSlider()
    {
        BGMAudioSource.volume = bgmVolume.value; //슬라이더 값을 오디오소스의 volume에 대입

        bgmVol = bgmVolume.value;
        sfxVol = SFXVolume.value;
        PlayerPrefs.SetFloat("bgmvol", bgmVol); //"bgmvol"이라는 키에 bgmVol 저장
        PlayerPrefs.SetFloat("sfxvol", sfxVol);
    }
}
