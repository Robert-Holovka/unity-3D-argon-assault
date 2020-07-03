using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    internal class SceneLoader : MonoBehaviour
    {
        [SerializeField] float splashScreenDuration = 2f;

        private void Start() => Invoke("LoadFirstScene", splashScreenDuration);
        private void LoadFirstScene() => SceneManager.LoadScene(1);
    }
}
