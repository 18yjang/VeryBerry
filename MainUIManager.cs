using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 전환 기능 제공

public class MainUIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject howToMenu;
    public GameObject back1;

    void Start()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        howToMenu.SetActive(false);
    }

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //게임 중간에 꺼지지 않도록
        Screen.SetResolution(1280, 720, false); //게임 화면 크기 고정
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        //Debug.Log("Mouse Position : " + mousePos);
        if (mousePos.x > 490 && mousePos.x < 781 && mousePos.y < 383 && mousePos.y > 317 && optionMenu.activeSelf==false && howToMenu.activeSelf==false)
        {
            back1.SetActive(true);
        }
        else back1.SetActive(false);
    }

    public void OnClickStartButton() //"게임 시작" 버튼
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickHowToButton() //"게임 방법" 버튼
    {
        mainMenu.SetActive(false); //메인 메뉴 오브젝트 off
        howToMenu.SetActive(true); //게임방법 메뉴 오브젝트 on
    }

    public void OnClickOptionButton() //"옵션 설정" 버튼
    {
        mainMenu.SetActive(false); //메인 메뉴 오브젝트 off
        optionMenu.SetActive(true); //옵션 메뉴 오브젝트 on
    }

    public void OnClickGoToMainButton() //"메인으로" 버튼
    {
        if (optionMenu.activeSelf == true) //옵션 메뉴일 경우
        {
            optionMenu.SetActive(false); //옵션 메뉴 오브젝트 off
            mainMenu.SetActive(true); //메인 메뉴 오브젝트 on
        }
        else //게임방법 메뉴일 경우
        {
            howToMenu.SetActive(false); //게임방법 메뉴 오브젝트 off
            mainMenu.SetActive(true); //메인 메뉴 오브젝트 on
        }
    }

    public void OnClickQuitButton() //"끝내기" 버튼
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); //게임 종료
#endif
    }
}
