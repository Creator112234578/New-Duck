using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void PlayGameTutor()
    {
        SceneManager.LoadScene("GameTutorial");
    }

    public void PlayGameLV1()
    {
        SceneManager.LoadScene("GameLevel1");
    }

    public void PlayGameLV2()
    {
        SceneManager.LoadScene("GameLevel2");
    }

    public void PlayGameLV3()
    {
        SceneManager.LoadScene("GameLevel3");
    }
}