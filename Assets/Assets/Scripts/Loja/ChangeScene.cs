
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void TrocaScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
