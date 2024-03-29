using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gameManager : MonoBehaviour
{
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject failTxt;
    public GameObject card;
    public GameObject limitTime;
    float time;
    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;
    public AudioClip match;
    public AudioSource audioSource;

    private void Awake()
    {
        I = this;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray(); 

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            // newCard를 cards로 옮겨줘!!
            newCard.transform.parent = GameObject.Find("cards").transform;
            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);

        }
    }

    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 40.0f)
        {
            failTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void isMatched()
    {
        // 여기서 무엇인가 판단함
        // FirstCard 와 secondCard 같은지
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name; 
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            // 매칭 성공, 카드를 없애자
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                // 종료시키자
                Time.timeScale = 0f;
                endTxt.SetActive(true);
                //Invoke("GameEnd", 1f);
            }
        }
        else
        {
            // 매칭 실패, 덮자.
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent <card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }
}
