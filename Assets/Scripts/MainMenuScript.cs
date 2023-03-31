using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI t1, t2, t3;
    float c1 = 0f, c2 = 0f, c3 = 0f;
    int i = 0;

    public void BtnQuit()
    {
        Debug.Log("Aight I'm ragequittin'");
        Application.Quit();
    }

    void Update()
    {
        AAAAAAA_();
    }

    // Joke code, don't mind it
    private void AAAAAAA_()
    {
        Color color = new Color(c1, c2, c3);
        t1.color = color;
        t2.color = color;
        t3.color = color;

        c1 = Random.Range(0f, 1f);
        c2 = Random.Range(0f, 1f);
        c3 = Random.Range(0f, 1f);

        //------------------------------

        if (i % 3 == 0)
        {
            t1.alpha = 0f;
            t2.alpha = 255f;
        }
        else if (i % 3 == 1)
        {
            t2.alpha = 0f;
            t3.alpha = 255f;
        }
        else if (i % 3 == 2)
        {
            t3.alpha = 0f;
            t1.alpha = 255f;
        }

        i++;
    }
}
