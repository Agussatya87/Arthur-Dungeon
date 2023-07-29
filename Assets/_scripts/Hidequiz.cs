using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidequiz : MonoBehaviour
{
    public GameObject HideQuiz;

    public void ShowShop()
    {
        HideQuiz.SetActive(true);
    }


    public void Hide()
    {
        HideQuiz.SetActive(false);
        Time.timeScale = 1f; 
    }

   
    public void OnExitButtonClick()
    {
        Hide(); 
    }
}
