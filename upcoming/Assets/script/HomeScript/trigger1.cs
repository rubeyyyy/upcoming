
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger1 : MonoBehaviour
{
    

    void OnTriggerEnter(Collider coll)
    {
        
        SceneManager.LoadScene("quiz");

    }
}
