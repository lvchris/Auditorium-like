using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    private IntVariable _levelNumber;
    #endregion

    #region Private
    private PlayGame _playGame;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        _playGame = GetComponent<PlayGame>();
        _levelNumber.value = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("StartMenu");
        }

        if (Input.GetKey(KeyCode.T))
        {
            SceneManager.LoadScene("TestingScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("StartMenu");
        }

        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.T)) _playGame.enabled = !_playGame.enabled;
    }
    #endregion
}
