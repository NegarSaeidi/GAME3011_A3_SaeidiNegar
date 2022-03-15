using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void OnStartMiniGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnCloseMiniGame()
    {
        SceneManager.LoadScene("Start");
    }
}
