using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class QuizManager : MonoBehaviour
{
    public GameObject QuestionText;
    public Button[] buttons;
    public int Score;


    public string[] Question;
    public string[] Question1;
    public string[] Question2;
    public string[] Question3;
    public string[] Question4;
    public string[] Question5;
    public string[] Question6;
    public string[] Question7;
    public string[] Question8;
    public string[] Question9;
    public string[] Question10;
    private int CurrentQuestionID;
    private int currentarraycount;

    private void Start()
    {
        int getQuestion = Random.RandomRange(0, 9);
        ActivateSetQuestion();
    }


    // Update is called once per frame
    void Update()
    {
    }


    public void Correct()
    {
        Score++;
        Debug.Log("Correct");
        Debug.Log(Score);
        if (Score == 5)
        {
            Debug.Log("You've Won");
        }
        currentarraycount++;
    }
    public void Wrong()
    {
        Debug.Log("to bad");
    }

    public void ActivateSetQuestion()
    {
        int getQuestion = Random.RandomRange(0, 9);
        Debug.Log(getQuestion);
        if (getQuestion == 0) { SetQuestion(0, Question1); }
        else if (getQuestion == 1) { SetQuestion(1, Question2); }
        else if (getQuestion == 2) { SetQuestion(2, Question3); }
        else if (getQuestion == 3) { SetQuestion(3, Question4); }
        else if (getQuestion == 4) { SetQuestion(4, Question5); }
        else if (getQuestion == 5) { SetQuestion(5, Question6); }
        else if (getQuestion == 6) { SetQuestion(6, Question7); }
        else if (getQuestion == 7) { SetQuestion(7, Question8); }
        else if (getQuestion == 8) { SetQuestion(8, Question9); }
        else if (getQuestion == 9) { SetQuestion(9, Question10); }
    }
    void SetQuestion(int q, string[] AText)
    {
        if (Question[q] != null)
        {
            Debug.Log(q + "  " + AText);
            QuestionText.GetComponentInChildren<Text>().text = Question[q];
            int randomizer = Random.RandomRange(1, 90);
            if (randomizer >=1 && randomizer<=30)
            {
                int reset = 0;
                int count = 2;
                foreach (Button item in buttons)
                {
                    if (count >= 3) { count = reset; }
                    item.GetComponentInChildren<Text>().text = AText[count];
                    if (count == 0)
                    {
                        item.GetComponent<ButtonManager>().CorrectChoice = true;
                    }
                    count++;
                }
                count = reset;
                //if randomizer = 2 offset
            }
            else if (randomizer >=31 && randomizer<=60)
            {
                int reset = 0;
                int count = 2;
                foreach (Button item in buttons)
                {
                    if (count >= 3) { count = reset; }
                    item.GetComponentInChildren<Text>().text = AText[count];
                    if (count == 0)
                    {
                        item.GetComponent<ButtonManager>().CorrectChoice = true;
                    }
                    count++;
                }


            }
            //if randomizer = 3 offset
            else if (randomizer >=61 && randomizer<=90)
            {
                int reset = 0;
                int count = 2;
                foreach (Button item in buttons)
                {
                    if (count >= 3) { count = reset; }
                    item.GetComponentInChildren<Text>().text = AText[count];
                    if (count == 0)
                    {
                        item.GetComponent<ButtonManager>().CorrectChoice = true;
                    }
                    count++;
                }

            }
            Question[q] = null;
        } else { ActivateSetQuestion(); }
    }


    void ReadFile(string FN)
    {
        string path = "Assets/Resources/" + FN + ".txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
