using UnityEngine;

namespace Scripts
{
    internal class MusicPlayer : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectsOfType<MusicPlayer>().Length > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
