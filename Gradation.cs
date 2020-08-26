using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gradation : MonoBehaviour
{
    // 게이지

    public Gradient gradient;
    private Image img;
    public TimeBar timeBar;
    public float gaugeColor;

    void Start()
    {
        gaugeColor = 0;
        img = transform.GetComponent<Image>();
    }

    void Update()
    {
        gaugeColor -= (Time.deltaTime * 100);  // 시간당 -100점
        img.color = gradient.Evaluate(gaugeColor/1000);   // 최대 1000점 
        if (img.color == Color.black)
        {
            SceneManager.LoadScene("Scene_GameOver");
        }

        /*else if (gaugeColor)
        {
            SceneManager.LoadScene("Scene_GameOver");
        }*/
    }
}
