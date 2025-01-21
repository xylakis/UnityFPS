using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string newGameScene = "CodingEnemies";


    public void StartNewGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void StartMiniDungeonScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartMaterialScene()
    {
        SceneManager.LoadScene("materialScene");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#else
        // This works only if it's a running application 
        // and not within the editor 
        Application.Quit();

#endif
    }
}
