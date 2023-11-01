using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5.0f;
    float energy = 0.0f;
    bool isFull = false;
    public int type;
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;

        if (type == 1)
        {
            full = 10.0f;
        }
        else if (type == 2)
        {
            full = 7.0f;
        }

        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
            {
                transform.position += new Vector3(0f, -0.05f, 0f);

            }
            else if (type == 1)
            {
                transform.position += new Vector3(0f, -0.03f, 0f);

            }
            else if (type == 2)
            {
                transform.position += new Vector3(0f, -0.1f, 0f);
            }

            if (transform.position.y < -16f)
            {
                // ���ӿ���
                gameManager.I.gameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0, 0);
            }
            Destroy(gameObject, 3.0f); // 3�� �ڿ� ���ش�.
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 1f;
                Destroy(coll.gameObject); // ���� �����(�����) �� ���ӿ�����Ʈ�� ������.
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
            else
            {
                if (isFull == false)
                {
                    gameManager.I.addCat();
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;
                }
                
            }
           
        }
    }
}
