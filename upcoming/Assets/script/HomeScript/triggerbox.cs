using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerbox : MonoBehaviour
{
    void OnTriggerEnter(Collider coll)
    {
        SceneManager.LoadScene("boxCollider");

    }
}
