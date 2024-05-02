using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    GameObject player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseStartMenu;
    [SerializeField] GameObject menus;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ResetPauseUI();
    }
    public void OnPauseGame()
    {
        if(isPaused)
        {
            UnpauseGame();
        }
        else PauseGame();
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        player.GetComponent<PlayerInput>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }
    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        player.GetComponent<PlayerInput>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        ResetPauseUI();
    }
    public void ResetPauseUI()
    {
        for (int i = 0; i < menus.transform.childCount; i++)
        {
            menus.transform.GetChild(i).gameObject.SetActive(false);
        }
        pauseStartMenu.SetActive(true);
    }
    public void StopGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
