using UnityEngine;

namespace Scripts
{
    internal class PlayerController : MonoBehaviour
    {
        [Header("Translation")]
        [Tooltip("In m/s")] [SerializeField] float translationSpeed = 15f;
        [SerializeField] float xRange = 5f;
        [SerializeField] float yRange = 3f;

        [Header("Rotation")]
        [SerializeField] float pitchFactor = 1f;
        [SerializeField] float yawFactor = 1f;

        [SerializeField] GameObject[] guns;

        private float xInput, yInput;
        private bool isControlEnabled = true;
        private Vector3 projectileCenter;

        private void Start()
        {
            projectileCenter = new Vector3(0, 0, Camera.main.farClipPlane);
        }

        private void Update()
        {
            if (!isControlEnabled) return;

            xInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");

            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }

        private void ProcessTranslation()
        {
            // Local position jer timeline upravlja ovime !!!
            Vector3 currentPos = transform.localPosition;

            float xOffset = xInput * translationSpeed * Time.deltaTime;
            xOffset += currentPos.x;
            xOffset = Mathf.Clamp(xOffset, -xRange, xRange);

            float yOffset = yInput * translationSpeed * Time.deltaTime;
            yOffset += currentPos.y;
            yOffset = Mathf.Clamp(yOffset, -yRange, yRange);

            // Local position jer timeline upravlja ovime !!!
            transform.localPosition = new Vector3(xOffset, yOffset, currentPos.z);
        }

        private void ProcessRotation()
        {
            Quaternion localRotationUnscaled = Quaternion.FromToRotation(transform.localPosition, projectileCenter);
            Quaternion localRotationScaled = localRotationUnscaled;
            localRotationScaled.x *= pitchFactor;
            localRotationScaled.y *= yawFactor;
            transform.localRotation = localRotationScaled;
        }

        private void ProcessFiring() => ProcessGuns(Input.GetButton("Fire"));

        private void ProcessGuns(bool active)
        {
            foreach (GameObject gun in guns)
            {
                var emissionModule = gun.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = active;
            }
        }

        private void OnPlayerDeath() // Called by String reference
        {
            isControlEnabled = false;
        }
    }
}