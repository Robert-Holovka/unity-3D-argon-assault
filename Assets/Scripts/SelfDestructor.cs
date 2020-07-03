using UnityEngine;

namespace Scripts
{
    internal class SelfDestructor : MonoBehaviour
    {
        private const float destroyAfter = 5f;

        private void Start() => Destroy(gameObject, destroyAfter);
    }
}
