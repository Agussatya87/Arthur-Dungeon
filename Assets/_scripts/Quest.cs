using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Quest : MonoBehaviour
{
    public Text soalText;
    public Text[] jawabanText;
    public int[] randomJawaban;

    public QuizController quizController;
    int nomerSoal;
    public int[] randomSoals;

    [Header("Quest Timer")]
    public int increaseTime;
    public int decreaseTime;
    public Slider timerSlider;

    // Start is called before the first frame update
    void Start()
    {
        randomNomerSoal();
        GenerateQuest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomNomerSoal()
    {
        for (int i = 0; i < randomSoals.Length; i++)
        {
            int a = randomJawaban[i];
            int b = Random.Range(0, randomSoals.Length);
            randomSoals[i] = randomSoals[b];
            randomSoals[b] = a;
        }
    }


    void randomNomerJawaban()
    {
        for(int i = 0; i < randomJawaban.Length; i++)
        {
            int a = randomJawaban[i];
            int b = Random.Range(0, randomJawaban.Length);
            randomJawaban[i] = randomJawaban[b];
            randomJawaban[b] = a;
        }
    }
    void GenerateQuest()
    {
        randomNomerJawaban();
        soalText.text = quizController.soals[randomSoals[nomerSoal]].elementSoal.soal;

        for (int i = 0; i < jawabanText.Length; i++)
        {
            jawabanText[i].text = quizController.soals[randomSoals[nomerSoal]].elementSoal.jawaban[randomJawaban[i]];
        }
    }

    public void JawabanSoal()
    {
        Text currentJawaban = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>();
        if (currentJawaban.text == quizController.soals[randomSoals[nomerSoal]].elementSoal.jawaban[quizController.soals[randomSoals[nomerSoal]].elementSoal.jawabanBenar])
        {
            Debug.Log("Benar");

            timerSlider.value += increaseTime;
        }
        else
        {
            Debug.Log("Salah");

            timerSlider.value -= decreaseTime;
        }
    }
}
