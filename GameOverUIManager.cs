using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //씬 전환 기능 제공

public class GameOverUIManager : MonoBehaviour
{
    public Text currentscore;
    public Text Maxscore;  // 저장되는지 확인해야 함

    void Update()
    {
        currentscore.text = "최종 점수\n" + GameManager.Manager.totalPoint.ToString() + " 점";

        if (GameManager.Manager.totalPoint > PlayerPrefs.GetInt("Maximum"))
        {
            GameManager.Manager.Maximum = GameManager.Manager.totalPoint;
            PlayerPrefs.SetInt("Maximum", GameManager.Manager.Maximum);
        }

        Maxscore.text = "최고 점수\n" + PlayerPrefs.GetInt("Maximum") + " 점";
    }

    public void OnClickRetryButton() //"다시하기" 버튼
    {
        SceneManager.LoadScene("Game");
    }

    
}
