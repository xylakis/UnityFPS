using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Check one of the two tutorials for more details on player/camera movement taken from https://www.youtube.com/watch?v=_QajrabyTJc or https://www.youtube.com/watch?v=swOfmyJvb98&t=186s&ab_channel=Mike%27sCode

public class Mouse_Look : MonoBehaviour
{
    // Input the sensitivity of our mouse
    public float mouseSensitivity = 150f;
    public Transform playerBody;
    float xRotation = 0f;
  
    public float topClamp = -90f;
    public float bottomClamp = 90f;

    //Declare these in your class
    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    public float m_refreshTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisble
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime return the seconds that have elapses since the last frame 
        //Input.GetAxis("Mouse X") returns how much the mouse has moved in the X direction since the last frame.

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -=  mouseY;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        
        //we rotate on the X axis (camera)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //we rotate on the Y axis (the parent First-person character)
        playerBody.Rotate(Vector3.up * mouseX);


        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }

        //Debug.Log(m_lastFramerate);



    }
}
