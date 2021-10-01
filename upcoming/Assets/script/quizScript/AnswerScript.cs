using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizmanager;

    public Color startColor;
    

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
       if(isCorrect)
        { 
            StartCoroutine(WaitForNext()); //starts the IEnumerator
         quizmanager.correct();
        }
        else
        {
            //wrong
            StartCoroutine(WaitForNext());
            GetComponent<Image>().color = Color.red;
            quizmanager.wrong();
        }
     }
     
IEnumerator WaitForNext()
{
    GetComponent<Image>().color = Color.green;
       //GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.15f);
    GetComponent<Image>().color = startColor;
    StopCoroutine(WaitForNext());
}
}
