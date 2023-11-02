using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void openCard()
    {
        if(Time.timeScale != 0)
        {
            // 1. Animator isOpen -> true  2. Front setActive = true 3. back setActive = false
            anim.SetBool("isOpen", true);
            transform.Find("front").gameObject.SetActive(true);
            transform.Find("back").gameObject.SetActive(false);

            if (gameManager.I.firstCard == null)
            {
                gameManager.I.firstCard = gameObject;
            }
            else
            {
                gameManager.I.secondCard = gameObject;
                gameManager.I.isMatched();
            }
        }
        
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
