using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySelection : MonoBehaviour
{
   public void PlayGame ()
    {
        SceneManager.LoadScene(Random.Range(1,4));
    }
}
