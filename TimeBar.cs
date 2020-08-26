using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    // public Text TimeTxt;       // 시간 초 텍스트
    public Slider gauge;
    public float fillAmount;
    float currentTime;
    float startingTime;

    void Start()
    {
        fillAmount = 0;
        currentTime = 60;  // 제한시간
        startingTime = currentTime;
    }
    void Update()
    {
        GetCurrentFill();
        currentTime = currentTime - Time.deltaTime;  // 한 프레임당 시간(컴퓨터마다 다름)

        if (currentTime <= 0)  // 완전 0 불가능
        {
            if(GameManager.Manager.totalPoint == 0)
            {
                SceneManager.LoadScene("Scene_GameOver");         // 0점일 경우 
            }
            else SceneManager.LoadScene("Scene_Ending");
            //currentTime = 120;

        }
    }

    void GetCurrentFill()
    {
         float fillAmount = 1 - currentTime / startingTime;
         gauge.value = fillAmount;
        
    }
}
