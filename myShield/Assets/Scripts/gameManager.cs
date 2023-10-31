using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject square;
    public GameObject endPanel;
    public Text timeTxt;
    public Text thisScoreTxt;
    public Text maxScoreTxt;
    public Animator anim;
    float alive = 0f;
    bool isRunning = true;
    public static gameManager I; // 싱글톤 처리

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f; // 시간 초기화 해주기.
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver()
    {
        isRunning = false;
        anim.SetBool("isDie", true);
        Invoke("timeStop", 0.5f);
        endPanel.SetActive(true);
        thisScoreTxt.text = alive.ToString("N2");
        if (PlayerPrefs.HasKey("bestscore") == false)
        {
            PlayerPrefs.SetFloat("bestscore", alive);
        }
        else
        {
            if (alive > PlayerPrefs.GetFloat("bestscore"))
            {
                PlayerPrefs.SetFloat("bestscore", alive);
            }
        }
        float maxScore = PlayerPrefs.GetFloat("bestscore");
        maxScoreTxt.text = maxScore.ToString("N2");
        
    }

    void timeStop()
    {
        Time.timeScale = 0f;
    }

    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
