using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject panelPause;
    public GameObject panelRestart;
    public GameObject panelWin;
    public GameObject buttonPause;
    public SnakeTail SnakeTail;
    public Snake Snake;

       

    public void PauseButton()
    {
        panelPause.SetActive(true);
        buttonPause.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        panelPause.SetActive(false);
        buttonPause.SetActive(true);
        Time.timeScale = 1f;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(Snake.LevelIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SnakeTail.BlockCount = 0;
        Time.timeScale = 1f;
    }

    public void NewGameButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SnakeTail.BlockCount = 0;
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SnakeTail.BlockCount = 0;
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SnakeTail.BlockCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    
    public void NextLevelButton()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
    }
}
