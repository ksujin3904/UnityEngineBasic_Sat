using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManage Ŭ���� ��� ����
/// <summary>
/// scene �̵��� ���õ� Ŭ����
/// </summary>

public class SceneMover
{
    public static void MoveTo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void MoveTo(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
