using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIbehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }
    public void Play()
    {
        //loads the scene numbered 1 in the build settings.
        //Debug.Log("wtf");
        SceneManager.LoadScene(2);
    }

    #region MainMenu
    public void Quit()
    {
        // does the same thing as QuitScript.QuitGame();
        Debug.Log("Quitting");
        Application.Quit();
    }
    #endregion

    #region InGame
    public void Menu()
    {
        //loads the scene numbered 1 in the build settings.
        Debug.Log("Menu time");
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }
    #endregion

    #region Global
    public void Loadlevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    #endregion








}
