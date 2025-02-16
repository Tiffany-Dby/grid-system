using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    public void SwitchToTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName == "GameScene")
        {
            Time.timeScale = 1;
        }
    }

    public void SwitchToTargetSceneOnKeyDown(string sceneName, KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void TriggerWinMenu()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
        //Dev mode
        //SwitchToTargetScene("MainMenu");
    }
}
