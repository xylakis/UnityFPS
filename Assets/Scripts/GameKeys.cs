using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeys : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
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
