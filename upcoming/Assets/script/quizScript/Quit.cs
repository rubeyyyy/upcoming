using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public GameObject GOPanel;

    void Start()
    {
        GOPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider coll)
    {
    
        GOPanel.SetActive(true);

    }

    public void no()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void yes()
    {
         Application.Quit();
    }
}
