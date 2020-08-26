using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FarmerMove : MonoBehaviour
{
    public Image[] farmer;
    public Gradation grad;
    int farmernum;
    int[] isFlip = { 1, -1 };  // 1 : 오른쪽, -1 : 왼쪽
    float isFlipX;
    float activeTime, totalTime, isDeactive, moveTime;
    float speed;
    Vector3 reset;
    public GameObject childManager;
    public GameObject gameManager;
    //bool pause = false;
    

    void Start()
    {
        for (int i=0; i<farmer.Length; i++)
        {
            farmer[i].enabled = false;
        }

        FarmerSet();
    }

    void Update()
    {
            activeTime = activeTime + Time.deltaTime;

        if (GameObject.Find("GameManager").GetComponent<GameManager>().isFever == false) //피버타임이 아닐 때
        {
            if (activeTime > totalTime + 1)   // 농부 비활성화
            {
                FarmerOff();
            }

            else if (activeTime > isDeactive)
            {
                farmer[farmernum].enabled = true;  // 농부, 강아지 활성화되어 있을 때

                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) ||
                    Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))     // 키 누르면 점수 차감
                {
                    grad.gaugeColor -= grad.gaugeColor/2;       // 0.5*       포인트가 깎이는 대신 게이지 색상은 되돌아옴
                    gameManager.GetComponent<GameManager>().totalPoint -= 2;     // 깎는 점수를 조절해야함

                    if (farmernum == 1 || farmernum == 2 || farmernum == 4 || farmernum == 5 || farmernum == 7 || farmernum == 8)
                    {
                        childManager.GetComponent<ChildManager>().Caught(1);
                        FarmerOff();
                    }
                    else if (farmernum == 0 || farmernum == 3 || farmernum == 6)
                    {
                        childManager.GetComponent<ChildManager>().Caught(2);
                        FarmerOff();
                    }

                }

                if (activeTime < totalTime)
                {
                    FarmerLocation();
                }
                else if (activeTime > totalTime + 1)  // 0.5초 멈춤
                {
                    FarmerOff();
                }
            }
        }
        else //피버타임일 때
        {
            FarmerOff();
        }
    }

    void FarmerSet()    // 농부 좌우 반전, 시간 랜덤 설정 및 위치 저장
    {
        // 좌우반전
        farmernum = Random.Range(0, farmer.Length);
        isFlipX = isFlip[Random.Range(0, 2)];
        farmer[farmernum].rectTransform.localScale = new Vector3(isFlipX, 1f, 1f);

        // 시간
        activeTime = 0.0f;
        totalTime = 6;
        isDeactive = 4.5f;

        // 위치, 속도 저장
        reset = farmer[farmernum].rectTransform.position;
        speed = Random.Range(30, 40) * Time.deltaTime;
    }

    void FarmerLocation()  // 이미지 방향대로 위치 이동
    {
        farmer[farmernum].rectTransform.Translate(speed * isFlipX, 0, 0);
    }

    void FarmerOff()   // 베리 비활성화
    {
        farmer[farmernum].enabled = false;
        farmer[farmernum].rectTransform.position = reset;
        FarmerSet();
    }
}
