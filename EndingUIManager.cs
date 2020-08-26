using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 전환 기능 제공
using UnityEngine.UI;


public class EndingUIManager : MonoBehaviour
{
    public Text currentScore;
    public Text MaxScore;  // 저장되는지 확인해야 함

    public Image imgButton;
    public float FadeTime = 2.0f; //fade 효과 재생시간
    float start, end;
    float time = 0f;
    bool isPlaying = false;

    void Update()
    {
        currentScore.text = "최종 점수\n" + GameManager.Manager.totalPoint.ToString() + " 점";

        if (GameManager.Manager.totalPoint > PlayerPrefs.GetInt("Maximum"))
        {
            GameManager.Manager.Maximum = GameManager.Manager.totalPoint;
            PlayerPrefs.SetInt("Maximum", GameManager.Manager.Maximum);
        }

        MaxScore.text = "최고 점수\n" + PlayerPrefs.GetInt("Maximum") + " 점";
    }

    public void OnClickMainButton() //"메인화면으로" 버튼
    {
            SceneManager.LoadScene("Scene_MainUI"); //메인 화면으로 전환
    }

    void Awake()
    {
        OutStartFadeAnim();
    }

    public void OutStartFadeAnim()
    {
        if(isPlaying == true) //중복재생 방지
        {
            return;
        }
        start = 0f;
        end = 1.0f;
        StartCoroutine("fadeoutplay"); //코루틴 실행
    }

    public void InStartFadeAnim()
    {
        if(isPlaying == true)
        {
            return;
        }
        StartCoroutine("fadeintanim");
    }

    IEnumerator fadeoutplay() //페이드아웃 기능 함수
    {
        yield return new WaitForSeconds(0.7f); //0.7초 딜레이
        isPlaying = true;

        Color fadeColor = imgButton.color;
        time = 0f;
        fadeColor.a = Mathf.Lerp(start, end, time);

        while(fadeColor.a < 1.0f)
        {
            time += Time.deltaTime / FadeTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            imgButton.color = fadeColor;
            yield return null;
        }

        isPlaying = false;
    }
}
