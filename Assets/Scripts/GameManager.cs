using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static float terrainSpeed = 8f;
    public TextMeshProUGUI distanceText;
    public static float distance;
    float counter = 0, maxCount = 20;

    public static bool isPaused = false;
    public GameObject pauseMenu;

    public AudioSource bgm, hitSound, gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
        distance = 0;
        distanceText.text = "0m";
    }

    // Update is called once per frame
    void Update()
    {
        RunDistance();

        if (Input.GetKeyDown(KeyCode.Escape) && GameLoader.isLoading == false && Player.playerHealth > 0)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Player.playerHealth <= 0)
        {
            bgm.Stop();
        }
    }

    void RunDistance()
    {
        if (GameManager.isPaused == false && Player.playerHealth > 0)
        {
            if (counter < maxCount)
            {
                counter += 1;
            } else
            {
                counter = 0;
                distance += 1;
                distanceText.text = distance.ToString() + "m";
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        bgm.volume = 0.5f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        bgm.volume = 1f;
        isPaused = false;
    }

    /*public void PlayAudio(string audioName)
    {
        switch (audioName)
        {
            case "hitSound":
                hitSound.Play();
                break;

            case "gameOverSound":
                gameOverSound.Play();
                break;
        }
    }*/
}