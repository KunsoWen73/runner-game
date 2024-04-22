using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    private void Start()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;
        Debug.Log("Screen Width: " + screenWidth);
        Debug.Log("Screen Height: " + screenHeight);
    }
}
