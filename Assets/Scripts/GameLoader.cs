using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool isLoading = false;
    public AudioSource bgm;

    float elapsedTime = 0;

    public void LoadNextScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        GameManager.isPaused = false;
        isLoading = true;
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        isLoading = false;
        SceneManager.LoadScene(sceneIndex);
    }

    private void Update()
    {
        if (isLoading)
        {
            elapsedTime += Time.deltaTime;
            bgm.volume = Mathf.Lerp(1f, 0f, elapsedTime/transitionTime);
        }
    }
}
