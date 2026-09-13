using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SwitchScene(int number)
    {
        SceneManager.LoadSceneAsync(number);
    }
}
