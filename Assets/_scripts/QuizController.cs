using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [System.Serializable]
    public class Soal
    {
        [System.Serializable]
        public class ElementSoal
        {
            [TextArea]
            public string soal;

            public string[] jawaban;

            public int jawabanBenar;
        }

        public ElementSoal elementSoal;
    }

    public List<Soal> soals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
