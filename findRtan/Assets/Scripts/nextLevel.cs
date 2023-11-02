using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
