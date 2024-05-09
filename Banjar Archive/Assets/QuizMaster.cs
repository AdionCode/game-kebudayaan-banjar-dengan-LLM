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

        //while (numbers.Count > 0)
        //{
        //    //int numRan = Random.Range(0, numbers.Count);
        //    ////answer[numbers[numRan]].sprite = data[idData].answer[a];
        //    //Debug.Log(a++);
        //    //numbers.RemoveAt(numRan);
        //}
    }

    public void cekJawaban()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            int numRan = Random.Range(0, numbers.Count);
            //answer[numbers[numRan]].sprite = data[idData].answer[a];
            Debug.Log(a++);
            Debug.Log(answer[numbers[numRan]]);
            numbers.RemoveAt(numRan);
        }
    }


}