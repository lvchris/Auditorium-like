using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    #region Unity Lifecycle
    private void Awake()
    {
        SceneManager.LoadScene("Camera", LoadSceneMode.Additive);
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
        SceneManager.LoadScene("Background", LoadSceneMode.Additive);
    }
    #endregion
}
