using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    internal class CollisionHandler : MonoBehaviour
    {
        [SerializeField] float levelLoadDelay = 1f;
        [SerializeField] GameObject deathFX;

        private void OnTriggerEnter(Collider other)
        {
            StartDeathSequence();
        }

        private void StartDeathSequence()
        {
            SendMessage("OnPlayerDeath");
            deathFX.SetActive(true);
            Invoke("ReloadScene", levelLoadDelay);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
