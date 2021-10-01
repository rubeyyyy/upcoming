using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class BScore : MonoBehaviour
{
    public AudioSource bpoint;

    public TextMeshProUGUI scoreText;
    float score = 0;
    //public GameObject GOPanel;


    private void Start()
    {
        scoreText.text = "";
        //GOPanel.SetActive(false);
    }

    void Update()
    {

        scoreText.text = "Score: " + score;
    }


    void OnTriggerEnter(Collider coll)
    {
        bpoint.Play();
        score += 1;
    }
    

    



    

   
}
