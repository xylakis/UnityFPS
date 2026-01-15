using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartNewGame()
    {
        SceneManager.LoadScene("CodingEnemies");
    }

    public void StartMiniDungeonScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartFighterScene()
    {
        SceneManager.LoadScene("Simple_First_person_movement");
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
