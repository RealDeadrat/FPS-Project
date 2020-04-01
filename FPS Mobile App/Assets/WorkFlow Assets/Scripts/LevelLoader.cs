using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public Transform playerOneTransform;
    public Transform playerTwoTransform;
    public Transform playerThreeTransform;
    public Transform playerFourTransform;

    private int playersOut;

    private bool pOneOut;
    private bool pTwoOut;
    private bool pThreeOut;
    private bool pFourOut;
    void Start()
    {
        pOneOut = false;
        pTwoOut = false;
        pThreeOut = false;
        pFourOut = false;
        playersOut = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!pOneOut && playerOneTransform.position.y < -10)
        {
            pOneOut = true;
            playersOut++;
        }
        if (!pTwoOut && playerTwoTransform.position.y < -10)
        {
            pTwoOut = true;
            playersOut++;
        }
        if (!pThreeOut && playerThreeTransform.position.y < -10)
        {
            pThreeOut = true;
            playersOut++;
        }
        if (!pFourOut && playerFourTransform.position.y < -10)
        {
            pFourOut = true;
            playersOut++;
        }
        if(playersOut >= 3)
        {
            LoadNextLevel();
        }
       /* if (transform.position.y < -100)
        {
            transform.position.y = 200;
            transform.position.x = 0;
        }*/

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
