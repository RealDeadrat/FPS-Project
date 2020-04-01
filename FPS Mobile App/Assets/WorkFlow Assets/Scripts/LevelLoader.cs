using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            LoadNextLevel();
        }

    }

    public void LoadNextLevel()
    {
        int randInt = UnityEngine.Random.Range(1, 5);

        while(randInt == SceneManager.GetActiveScene().buildIndex)
        {
            randInt = UnityEngine.Random.Range(1, 5);
        }
        StartCoroutine(LoadLevel(randInt));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        //ignores try catch for some reason
        try
        {
            SceneManager.LoadScene(levelIndex);
        }
        catch(Exception e)
        {
            Debug.Log("Requested Scene Failed To Load, Returned To Main Menu");
            SceneManager.LoadScene(0);
        }
    }
}
