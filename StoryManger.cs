using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StoryManger : MonoBehaviour
{
    public VideoPlayer vp;
    public AudioSource aud;

    void Start()
    {
        Screen.SetResolution(1280, 720, false);
        vp.Play();
    }

    
    void Update()
    {
        if(vp.clip.length - vp.time < 4)
        {
            aud.volume -= Time.deltaTime * 0.1f;
        }

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Scene_MainUI");
        }

        if (!vp.isPlaying)
        {
            SceneManager.LoadScene("Scene_MainUI");
        }
    }
}
