using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }
}
