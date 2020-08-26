using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public Gradation grad;
    public int totalPoint;
    public int stagePoint;
    public int Maximum;
    public GameObject fever;

    public GameObject childManager;
    public GameObject berryManager;
    public GameObject UIOption;

    
    public Text Point;

    List<int> num;

    public GameObject imageFeverTime; //피버타임 이미지
    public GameObject image; //피버타임 함수가 잘 실행되는지 확인하기 위한 임시 이미지

    float feverTime = 0.0f; //피버타임이 진행된 시간
    float feverLimitTime = 7.0f; //피버타임 제한시간 7초로 설정

    float imageTime; //피버타임 이미지 띄운 시간

    public bool isFever = false; //피버타임 여부
    public bool ableFever = true; //쿨타임 찼는지 여부
    public bool isDelay = false; //피버타임 이미지 딜레이 여부
    public bool paused = false;

    List<int> points = new List<int>(); //피버타임 달성 점수를 저장할 points 리스트

    void Start()
    {
        imageFeverTime.SetActive(false); //피버타임 이미지 오브젝트 비활성화
        image.SetActive(false);

        Manager = this;
        //Screen.SetResolution(1280, 720, false);

        totalPoint = 0;
        num = berryManager.GetComponent<BerryImage>().berryOrder;
        num.Capacity = berryManager.GetComponent<BerryImage>().berryCount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {   
            UIOption.SetActive(true);
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        if (!paused)
        {
            UIOption.SetActive(false);
            Time.timeScale = 1;
        }

        //15*n 점 일 때마다 피버타임 실행 & 피버타임 실행 중이 아니어야 함 & 쿨타임이 다 차야 함 & 점수가 깎여서 되돌아온 경우 피버타임 실행x
        if (totalPoint > 0 && totalPoint % 15 == 0 && !isFever && ableFever && !points.Contains(totalPoint))
        {
            points.Add(totalPoint); //points 리스트에 해당 점수 추가
            StartCoroutine("ImageDelay"); //피버타임 이미지 함수 실행
            isFever = true;
        }
        if (isFever)
        {
            feverTime += Time.deltaTime;
            if (feverTime < feverLimitTime)
            {
                OnFever(); //피버타임 on
            }
            else
            {
                StartCoroutine("FeverCoolTime");
                OffFever(); //피버타임 off
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("Q")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("W")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("E")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("R")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("A")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("S")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("D")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.F))    // 키입력 확인 
            {
                for (int i = 0; i < num.Count; i++)
                {
                    if ((berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].CompareTag("F")) && (berryManager.GetComponent<BerryImage>().arrow[num[i]].activeSelf == true)) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                    {
                        OnPress();

                        if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry"))
                        {
                            totalPoint += 1;
                        }
                        else  // 마이너스
                        {
                            totalPoint -= 1;
                        }

                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                        break;
                    }
                }
            }
        }

        Point.text = totalPoint.ToString() + " 점";
    }

    public void OnPress()
    {
        grad.gaugeColor += 200;  // 누르면 200점
    }

    IEnumerator ImageDelay() //피버타임 이미지 2초 동안 유지시키는 함수
    {
        imageFeverTime.SetActive(true); //이미지 활성화
        isDelay = true;

        yield return new WaitForSeconds(1.5f); //2초 동안 딜레이

        isDelay = false;
        imageFeverTime.SetActive(false); //이미지 비활성화
        image.SetActive(true); //해당 함수가 잘 실행되는지 확인하기 위해서 이미지 활성화
    }

    IEnumerator FeverCoolTime()
    {
        ableFever = false;

        yield return new WaitForSeconds(8.0f); //8초 동안 쿨타임

        ableFever = true;
    }

    void OnFever() //피버타임 실행 함수
    {
        GameObject.Find("Tree").GetComponent<Image>().color = new Color(255/255, 190/255 , 255/255);      // 나무 색 보라색으로 변경
        //GameObject.Find("Back").GetComponent<Image>().color = new Color(255 / 255, 255 / 255, 255 / 255, 190 / 255);      // 배경 색 보라색으로 변경
        fever.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space) && !isDelay) //스페이스바 입력 확인 
        {
            for (int i = 0; i < num.Count; i++)
            {
                if (berryManager.GetComponent<BerryImage>().arrow[num[i]] != null) // 방향 베리 존재 유무 + 화살표 이미지가 나와있으면
                {
                    //OnPress(); 게이지바 색 바뀌는 거 무효화
                    if (berryManager.GetComponent<BerryImage>().berry[num[i]].CompareTag("Berry") &&
                        (berryManager.GetComponent<BerryImage>().currentTime[num[i]] / berryManager.GetComponent<BerryImage>().nextTime[num[i]] >= 0.7f))
                    {
                        totalPoint += 1;
                        childManager.GetComponent<ChildManager>().OnPress(num[i]/* 숫자에서 화살표 베리값으로 변경하기*/);
                        berryManager.GetComponent<BerryImage>().BerryOff(num[i]/*숫자에서 베리값으로*/);
                    }
                }
            }
        }
    }

    void OffFever() //피버타임 종료 함수
    {
        GameObject.Find("Tree").GetComponent<Image>().color = new Color(1, 1, 1);   // 나무 색 원상태로
        //GameObject.Find("Back").GetComponent<Image>().color = new Color(1, 1, 1, 1);   // 배경 색 원상태로
        isFever = false;
        fever.SetActive(false);
        feverTime = 0.0f; //피버타임 진행시간 초기화
        image.SetActive(false); //임시 이미지 비활성화
    }

    public void OnClickGoToMain() //"메인으로" 버튼
    {
        SceneManager.LoadScene("Scene_MainUI");
    }
    public void OnClickCancel() //"취소" 버튼
    {
        paused = !paused;
    }
}
