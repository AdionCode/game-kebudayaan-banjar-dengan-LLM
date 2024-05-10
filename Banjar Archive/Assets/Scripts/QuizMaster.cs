using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizMaster : MonoBehaviour
{
    [SerializeField] TMP_Text question;
    [SerializeField] Image[] answer;
    [SerializeField] QuizData[] data;
    [SerializeField] List<int> numbers = new List<int>();

    int a = 0;


    int idData;

    private void Start()
    {
        // Milih quiz random
        idData = Random.Range(0, data.Length);

        // set variable ke game
        question.text = data[idData].question;

        while (numbers.Count > 0) // Hati Hati Loop
        {
            int numRan = Random.Range(0, numbers.Count);
            if (a == 0)
            {
                answer[numbers[numRan]].tag = "Jawaban";
            }
            answer[numbers[numRan]].sprite = data[idData].answer[a];
            a++;
            numbers.RemoveAt(numRan); // Jangan Delete
        }


    }

    public void cekJawaban(GameObject test)
    {
        if (test.CompareTag("Jawaban"))
        {
            Debug.Log("Adalah Benar");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            int numRan = Random.Range(0, numbers.Count);
            //answer[numbers[numRan]].sprite = data[idData].answer[a];
            Debug.Log(a++ + " | " + numRan);
            Debug.Log(answer[numbers[numRan]]);
            numbers.RemoveAt(numRan);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(Random.Range(0, numbers.Count));
        }
    }


}