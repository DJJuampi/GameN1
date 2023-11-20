using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            finishSound.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        //PersistanceManager.Instance.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Saving CurrentLevel: " + nextLevelIndex);
        PersistanceManager.Instance.SetInt("CurrentLevel", nextLevelIndex);
        SceneManager.LoadScene(nextLevelIndex);
         PersistanceManager.Instance.Save();
    }
}
