using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageLevel : MonoBehaviour
{
    #region Serialized
    [SerializeField]
    private string[] _levels;
    [SerializeField]
    private IntVariable _levelNumber;
    #endregion

    #region Functions
    // Called by GameEventListener
    private void NextLevel()
    {
        if (_levelNumber.value + 1 < _levels.Length)
        {
            SceneManager.UnloadSceneAsync(_levels[_levelNumber.value]);
            SceneManager.LoadScene(_levels[++_levelNumber.value], LoadSceneMode.Additive);
        }
    }
    #endregion
}
