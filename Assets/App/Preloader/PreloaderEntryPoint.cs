using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloaderEntryPoint : MonoBehaviour
{
    private void Start()
    {
        //тут инициализируются все подсистемы (аналитика и т.д.)

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}