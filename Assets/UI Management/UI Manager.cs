using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject PauseMenu;
    public static bool isPaused = false;
    void Start()
    {
        PauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("hi");
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    // Update is called once per frame
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game..");
        Application.Quit();
    }
}
