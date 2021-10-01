using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BCollider : MonoBehaviour {

    public GameObject CurrentCube;
    public GameObject LastCube;
    public Text Text;
    public int Level;
    public bool Done;
    public GameObject GOPanel;


    // Use this for initialization
    void Start () {
        GOPanel.SetActive(false);
        newBlock();
	}

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void newBlock()
    {
        if(LastCube != null)
        {
            CurrentCube.transform.position = new Vector3(Mathf.Round(CurrentCube.transform.position.x),
             CurrentCube.transform.position.y,
             Mathf.Round(CurrentCube.transform.position.z));
            CurrentCube.transform.localScale = new Vector3(LastCube.transform.localScale.x - Mathf.Abs(CurrentCube.transform.position.x - LastCube.transform.position.x),
                                                           LastCube.transform.localScale.y,
                                                           LastCube.transform.localScale.z - Mathf.Abs(CurrentCube.transform.position.z - LastCube.transform.position.z));
            CurrentCube.transform.position = Vector3.Lerp(CurrentCube.transform.position, LastCube.transform.position, 0.5f) + Vector3.up * 5f;
            if(CurrentCube.transform.localScale.x <= 0f ||
               CurrentCube.transform.localScale.z <= 0f)
            {
                Done = true;
                GOPanel.SetActive(true);
                Text.gameObject.SetActive(true);
                Text.text = "Score: " + Level;
                StartCoroutine(x());
                return;
            }
                
        }
        LastCube = CurrentCube;
        CurrentCube = Instantiate(LastCube);
        CurrentCube.name = Level + "";
        CurrentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 0.5f, 0.5f, 0.5f));
        Level++;
        Camera.main.transform.position = CurrentCube.transform.position + new Vector3(100, 70f, -100);
        Camera.main.transform.LookAt(CurrentCube.transform.position + Vector3.down * 30f);
    }

    // Update is called once per frame
    void Update () {
        if (Done)
            return;

        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);

        var pos1 = LastCube.transform.position + Vector3.up * 10f;
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;

        if (Level % 2 == 0)
            CurrentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
        else
            CurrentCube.transform.position = Vector3.Lerp(pos1, pos2, time);


        if (Input.GetMouseButtonDown(0))
            newBlock();
	}

    IEnumerator x()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }
    public void exit()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Home");

    }

}
