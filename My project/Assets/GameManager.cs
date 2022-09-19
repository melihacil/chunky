using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        FindObjectOfType<SoundManager>().PlaySource(0);
    }


    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void PauseLevel()
    {
        Time.timeScale = 0f;
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1f;
    }



}
