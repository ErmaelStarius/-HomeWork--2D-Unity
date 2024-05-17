using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInfo : MonoBehaviour
{
    // ���� ������ ��ư
    public void GameQuit()
    {
        Debug.Log("���� ����");
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
