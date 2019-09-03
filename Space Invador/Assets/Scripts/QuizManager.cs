using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;

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
    private int EmptyQuestions;
    public GameObject fade;
    public Animator anim;
    public Image black;
    public Animator Thumbsup;
    public Animator ThumbsDown;

    private void Start()
    {
        int getQuestion = Random.Range(0, 9);
        ActivateSetQuestion(-1);
    }


    // Update is called once per frame
    void Update()
    {
    }


    public void Correct()
    {
        Thumbsup.Play("Thumbs_up");
        Question[CurrentQuestionID] = null;
        Score++;
        if (Score == 5)
        {
            //Debug.Log("You've Won");
        }
    }
    public void Wrong()
    {
        //Debug.Log("to bad");
        ThumbsDown.Play("Thumbs_Down");
    }

    public void ActivateSetQuestion(int q)
    {
        foreach (Button item in buttons)
        {
            item.GetComponentInChildren<ButtonManager>().CorrectChoice = false;
        }
        foreach (string item in Question)
        {
            if (item == null)
            {
                EmptyQuestions++;
                //Debug.Log(EmptyQuestions);
            }
        }
        if (EmptyQuestions != 8)
        {
            EmptyQuestions = 0;
            int getQuestion = Random.Range(0, 9);
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
            EmptyQuestions = 0;
        }
        else { fade.SetActive(true); StartCoroutine(Fading()); } }
    void SetQuestion(int q, string[] AText)
    {
        if (Question[q] != null)
        {
            QuestionText.GetComponentInChildren<Text>().text = Question[q];
            int randomizer = Random.Range(1, 3);
            if (randomizer ==1)
            {
                int reset = 0;
                int count = 1;
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
            else if (randomizer ==2)
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
            else if (randomizer ==3)
            {
                int reset = 0;
                int count = 3;
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
            CurrentQuestionID = q;
        } else { ActivateSetQuestion(CurrentQuestionID); }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("win");
    }

}
