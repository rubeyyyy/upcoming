using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public AudioSource Rans;
    public AudioSource Wans;
    public List<QuestionAndAnswer> QnA;
     public GameObject[] options;
    public int CurrentQuestion;

    public Text Questiontxt;
    public Text ScoreText;

    int totalquestion = 0;
    public int score;

    public GameObject quizpanel;
    public GameObject GOPanel;

    

    private void Start()
    {
        totalquestion = QnA.Count;
        GOPanel.SetActive(false);
        GenerateQuestion(); 
    }
    
    

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        GOPanel.SetActive(true);
        quizpanel.SetActive(false);
        ScoreText.text = score +"/"+ totalquestion;
        
    }


    public void exit()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Home");

    }

    public void correct()
    {
        Rans.Play();
        score += 1;
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
        //StartCoroutine(WaitForNext());

    }
   
    public void wrong()
    {
        Wans.Play();
        QnA.RemoveAt(CurrentQuestion);
        GenerateQuestion();
        //StartCoroutine(WaitForNext());

    }

    /*IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(1);
        GenerateQuestion();
    }*/

    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {

            //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
  

            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];

            if (QnA[CurrentQuestion].CorrectAnswers == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
 
        }
    }
    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count);


            Questiontxt.text = QnA[CurrentQuestion].Question;
            SetAnswer();
        }
        else
        {
            //StartCoroutine(WaitForNext());
            Debug.Log("OUT OF QUESTION");
            GameOver();
        }
    }
   /* IEnumerator WaitForNext()
        {
    
            yield return new WaitForSeconds(0.15f);
   
        }*/

}
