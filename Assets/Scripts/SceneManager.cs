using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadMenuScene()
    {
        ResumeTime();
        SceneManager.LoadScene("Menu");
    }

    public void LoadSampleScene()
    {
        ResumeTime();
        SceneManager.LoadScene("SampleScene");
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
