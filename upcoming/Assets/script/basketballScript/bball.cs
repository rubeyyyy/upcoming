using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bball : MonoBehaviour
{
    public GameObject GOPanel;
    // Start is called before the first frame update
    void Start()
    {
        GOPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider coll)
    {
    
        
         GOPanel.SetActive(true);

    }

     public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
       
       public void exit()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Home");

    }
}
