using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public bool isEscapeToExit;
    public bool pause;
    void Start()
    {
        pause = false;
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
            isEscapeToExit = true;
        else
            isEscapeToExit = false;
    }

    void Update()
    {
        Screen.SetResolution(1920, 1080, true);
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (isEscapeToExit)
                Application.Quit();
            else
            {
                if (SceneManager.GetActiveScene().name.Equals("Game1") && !pause)
                    pause = true;
                else if (SceneManager.GetActiveScene().name.Equals("Game1") && pause)
                    pause = false;
            }
        }
    }

    private void FixedUpdate()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void EnableDisablePause()
    {
        pause = !pause;
    }
    
    public bool IsPause()
    {
        return pause;
    }
}
