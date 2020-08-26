using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BerryImage : MonoBehaviour
{
    public Gradient gradient;
    public ChildManager childManager;
    public GameManager gameManager;
    public GameObject BerryImg;
    public GameObject MinusBerryImg;
    public GameObject Q;
    public GameObject W;
    public GameObject E;
    public GameObject R;
    public GameObject A;
    public GameObject S;
    public GameObject D;
    public GameObject F;

    public GameObject[] berry;
    public GameObject[] arrow;

    public int berryCount;             // 베리 총 개수
    public float minusBerryRatio;        // (벌레 먹은 베리/베리 총 개수) 비율   ex) 0.3
    public int[] berryDirection;       // 1=N, 2=S, 3=E, 4=W
    public List<int> berryOrder;      // 베리 순서

    public int[] treeNum;                 // 1 < 2 < 3
    public int[] levelNum;                // 1 < 2 < 3
    public int[] childFlip;

    RectTransform[] berry_pos;

    int i;
    float[] x_pos, y_pos;
    public float[] radius, currentTime, nextTime;
    float[] angle;
    //private bool pause = false;

    void Awake()
    {
        x_pos = new float[berryCount];
        y_pos = new float[berryCount];
        radius = new float[berryCount];

        currentTime = new float[berryCount];
        nextTime = new float[berryCount];

        angle = new float[berryCount];

        treeNum = new int[berryCount];
        levelNum = new int[berryCount];
        childFlip = new int[berryCount];
        berryDirection = new int[berryCount];
        berryOrder = new List<int>();

        berry = new GameObject[berryCount];
        arrow = new GameObject[berryCount];
        berry_pos = new RectTransform[berryCount];

        berryOrder.Capacity = berryCount;
    }

    void Start()
    {
        for (int j = 0; j < berryCount; j++)
        {
            StartCoroutine(BerryOn(j));  // 베리 활성화 실행
        }
    }

    void Update()
    {
        /*if (GameObject.Find("GameManager").GetComponent<GameManager>().paused == true)
        {
            pause = true;
        }
        else pause = false;
        */

        i = 0;
        for (i = 0; i < berryCount; i++)
        {
            if ((berry[i] != null)&&(berry[i].activeSelf==true))  // 베리 활성화되어 있을 때
            {
                if (!berryOrder.Contains(i))
                {
                    berryOrder.Add(i);
                }
                BerrySize(i);    // 베리 크기 커짐
            }

            else
            {
                if (berryOrder.Contains(i))
                {
                    berryOrder.Remove(i);
                }
            }
        }
    }

    void BerryLocation(int n)    // 베리 위치 랜덤 설정
    {
        berryDirection[n] = (int)Random.Range(1, 9);               // 방향 정하기   (NSEW)
        
        x_pos[n] = Random.Range((float)-500.0, (float)500.0);
        y_pos[n] = Random.Range((float)-5.0, (float)200.0);

        for (int m = 0; m < berryCount; m++)  // 중복없는 난수 생성
        {
            while ((berry[m] != null) && ((x_pos[n] > (berry_pos[m].anchoredPosition.x - 60)) && (x_pos[n] < (berry_pos[m].anchoredPosition.x + 60))) && ((y_pos[n] > (berry_pos[m].anchoredPosition.y - 60)) && (y_pos[n] < (berry_pos[m].anchoredPosition.y + 60))))
            {
                    x_pos[n] = Random.Range((float)-500.0, (float)500.0);
                    y_pos[n] = Random.Range((float)-5.0, (float)200.0);
                    m = 0;
            }
        }
    }

    void BerryTime(int n)    // 베리 시간 랜덤 설정
    {
        currentTime[n] = 0.0f;
        nextTime[n] = Random.Range(2, 5);
    }

    void BerryRotation(int n)  // 베리 각도 랜덤 설정
    {
        angle[n] = Random.Range(-45.0f, 45.0f);    // -45도에서 45도 사이
    }
    
    public void BerrySize(int n)    // 베리 크기 조절
    {
        currentTime[n] = currentTime[n] + Time.deltaTime;
        berry[n].GetComponent<Image>().color = gradient.Evaluate(currentTime[n] / nextTime[n]);
        
        if (currentTime[n] / nextTime[n] >= 0.7f)    // 보라색일 때 화살표 활성화
        {
            if(GameObject.Find("GameManager").GetComponent<GameManager>().isFever == false) //기본일 때
            {
                arrow[n].SetActive(true);
            }
        }

        berry_pos[n].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, radius[n]);   // 크기 설정
        berry_pos[n].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, radius[n]);

        if (currentTime[n] < nextTime[n] - 0.5f)   // 크기 조절
        {
                radius[n] += 0.2f;
        }

        else if (currentTime[n] > nextTime[n] + 1)   // 베리 비활성화 실행
        {
            BerryOff(n);
        }
    }

    void ForChild(int n)
    {
        // 주인공을 위해 베리 위치 저장해두기
        // 가로
        if (berry_pos[n].anchoredPosition.x >= -500.0f && berry_pos[n].anchoredPosition.x < -216.0f)
        {
            treeNum[n] = 1;

            if (berry_pos[n].anchoredPosition.x < -500.0f)
            {
                childFlip[n] = -1;  // 주인공 좌우 반전
            }
            else
            {
                childFlip[n] = 1;
            }
        }
        else if (berry_pos[n].anchoredPosition.x >= -216.0f && berry_pos[n].anchoredPosition.x < 146.0f)
        {
            treeNum[n] = 2;
            
            if (berry_pos[n].anchoredPosition.x < 0f)
            {
                childFlip[n] = -1;  // 주인공 좌우 반전
            }
            else
            {
                childFlip[n] = 1;
            }
        }
        else if (berry_pos[n].anchoredPosition.x >= 146.0f && berry_pos[n].anchoredPosition.x <= 500.0f)
        {
            treeNum[n] = 3;

            if (berry_pos[n].anchoredPosition.x < 500.0f)
            {
                childFlip[n] = -1;  // 주인공 좌우 반전
            }
            else
            {
                childFlip[n] = 1;
            }
        }

        // 세로
        if (berry_pos[n].anchoredPosition.y >= -5.0f && berry_pos[n].anchoredPosition.y < 60.0f) levelNum[n] = 1;               
        else if (berry_pos[n].anchoredPosition.y >= 60.0f && berry_pos[n].anchoredPosition.y < 130.0f) levelNum[n] = 2;
        else if (berry_pos[n].anchoredPosition.y >= 130.0f && berry_pos[n].anchoredPosition.y <= 200.0f) levelNum[n] = 3;

    }

    public void BerryOff(int n)   // 베리 비활성화
    {
        childFlip[n] = 1;

        Destroy(berry[n]);
        Destroy(arrow[n]);

        StartCoroutine(BerryOn(n));
    }

    IEnumerator BerryOn(int n)     // 베리 활성화
    {
        yield return new WaitForSeconds(Random.Range(1, 7));

        BerryLocation(n);
        BerryTime(n);
        BerryRotation(n);

        if (GameObject.Find("GameManager").GetComponent<GameManager>().isFever == false) //피버타임 아닐 때
        {
            if (n < (berryCount * (1 - 0.9*minusBerryRatio)))
            {
                berry[n] = Instantiate(BerryImg);
            }
            else
            {
                berry[n] = Instantiate(MinusBerryImg);
                nextTime[n] = 1;
            }
        }
        else //피버타임일 때
        {
            berry[n] = Instantiate(BerryImg);
        }

        berry[n].GetComponent<Transform>().SetParent(GameObject.Find("CanvasBerry").GetComponent<Transform>());
        berry[n].transform.localPosition = new Vector2(x_pos[n], y_pos[n]);

        switch(berryDirection[n])
        {
            case 1:
                {
                    arrow[n] = Instantiate(Q);
                }
                break;
            case 2:
                {
                    arrow[n] = Instantiate(W);
                }
                break;
            case 3:
                {
                    arrow[n] = Instantiate(E);
                }
                break;
            case 4:
                {
                    arrow[n] = Instantiate(R);
                }
                break;
            case 5:
                {
                    arrow[n] = Instantiate(A);
                }
                break;
            case 6:
                {
                    arrow[n] = Instantiate(S);
                }
                break;
            case 7:
                {
                    arrow[n] = Instantiate(D);
                }
                break;
            case 8:
                {
                    arrow[n] = Instantiate(F);
                }
                break;
        }

        arrow[n].GetComponent<Transform>().SetParent(GameObject.Find("CanvasBerry").GetComponent<Transform>());
        arrow[n].transform.localPosition = new Vector2(x_pos[n], y_pos[n]);

        berry_pos[n] = berry[n].GetComponent<RectTransform>();
        berry_pos[n].rotation = Quaternion.Euler(new Vector3(0, 0, angle[n]));

        ForChild(n);

        radius[n] = Random.Range((float)70.0, (float)80.0);
        arrow[n].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, radius[n] - 35);
        arrow[n].GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, radius[n] - 35);

        berry[n].SetActive(true);
        arrow[n].SetActive(false);

    }
}