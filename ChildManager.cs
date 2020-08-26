using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChildManager : MonoBehaviour
{

    public Image[] child;
    public Image farmer;
    public Image dog;
    public AudioSource f;
    public AudioSource d;

    float ticker;
    float waitingTime, fdWaitTime;
    public GameObject berryManager;


    void Start()
    {
        for (int i = 0; i < child.Length; i++)
        {
            child[i].enabled = false;
        }

        dog.enabled = false;
        farmer.enabled = false;
        ticker = 0.0f;
        waitingTime = 0.5f;
        fdWaitTime = 0.2f;
    }


    void Update()
    {
        for (int i = 0; i < child.Length; i++)
        {
            if (child[i].enabled == true)
            {
                ticker += Time.deltaTime;

                if (ticker > waitingTime)
                {
                    child[i].enabled = false;
                    ticker = 0.0f;
                }
            }
        }


        if (dog.enabled == true)
        {
            ticker += Time.deltaTime;

            if (ticker > fdWaitTime)
            {
                dog.enabled = false;
                ticker = 0.0f;
            }
        }


        if (farmer.enabled == true)
        {
            ticker += Time.deltaTime;

            if (ticker > fdWaitTime)
            {
                farmer.enabled = false;
                ticker = 0.0f;
            }
        }
    }

    public void OnPress(int bnum)
    {
        for (int i = 0; i < child.Length; i++)
        {
            if (child[i].gameObject.activeSelf == true)
            {
                child[i].enabled = false;
            }
        }

        if (berryManager.GetComponent<BerryImage>().treeNum[bnum] == 1)
        {
            switch (berryManager.GetComponent<BerryImage>().levelNum[bnum])
            {
                case 1:
                    {
                        child[0].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[0].enabled = true;
                    }
                    break;
                case 2:
                    {
                        child[1].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[1].enabled = true;
                    }
                    break;
                case 3:
                    {
                        child[2].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[2].enabled = true;
                    }
                    break;
            }
        }
        else if (berryManager.GetComponent<BerryImage>().treeNum[bnum] == 2)
        {
            switch (berryManager.GetComponent<BerryImage>().levelNum[bnum])
            {
                case 1:
                    {
                        child[3].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[3].enabled = true;
                    }
                    break;
                case 2:
                    {
                        child[4].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[4].enabled = true;
                    }
                    break;
                case 3:
                    {
                        child[5].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[5].enabled = true;
                    }
                    break;
            }
        }
        else if (berryManager.GetComponent<BerryImage>().treeNum[bnum] == 3)
        {
            switch (berryManager.GetComponent<BerryImage>().levelNum[bnum])
            {
                case 1:
                    {
                        child[6].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[6].enabled = true;
                    }
                    break;
                case 2:
                    {
                        child[7].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[7].enabled = true;
                    }
                    break;
                case 3:
                    {
                        child[8].rectTransform.localScale = new Vector3(berryManager.GetComponent<BerryImage>().childFlip[bnum], 1f, 1f);
                        child[8].enabled = true;
                    }
                    break;
            }
        }

        else Debug.Log("오류");
    }

    public void Caught(int whom)
    {
        if(whom == 1)
        {
            if (dog.IsActive())
            {
                ticker -= Time.deltaTime;
            }
            else
            {
                dog.enabled = true;
                d.Play();
            }
        }
        else if(whom == 2)
        {
            if (farmer.IsActive())
            {
                ticker -= Time.deltaTime;
            }
            else
            {
                farmer.enabled = true;
                f.Play();
            }
        }
    }

}
