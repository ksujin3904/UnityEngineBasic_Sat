using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManage 클래스 사용 가능
/// <summary>
/// scene 이동과 관련된 클래스
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
