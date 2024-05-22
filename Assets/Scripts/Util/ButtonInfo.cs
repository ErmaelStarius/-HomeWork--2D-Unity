using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInfo : MonoBehaviour
{
    // 게임 나가기 버튼
    public void GameQuit()
    {
        Debug.Log("게임 나감");
        Application.Quit();
    }

    public void GoIntro()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoInGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
