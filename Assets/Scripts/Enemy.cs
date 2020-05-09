using UnityEngine;

namespace Scripts
{
    internal class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject deathFX;
        [SerializeField] int scorePerHit = 12;
        [SerializeField] int hits = 1;

        private Transform spawnedAtRuntimeParent;
        private ScoreDisplay scoreBoard;
        private MeshRenderer meshRenderer;
        private bool isDead = default;

        private void Awake()
        {
            spawnedAtRuntimeParent = GameObject.FindWithTag("SpawnAtRuntime").transform;
            scoreBoard = FindObjectOfType<ScoreDisplay>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            AddBoxCollider();
        }

        private void AddBoxCollider()
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = false;
        }

        private void OnParticleCollision(GameObject other)
        {
            if (isDead) return;

            scoreBoard.OnEnemyHit(scorePerHit);
            hits--;

            if (hits <= 0)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            isDead = true;
            GameObject deathEffects = Instantiate(deathFX, transform.position, Quaternion.identity);
            deathEffects.transform.parent = spawnedAtRuntimeParent;
            meshRenderer.enabled = false;
            Destroy(gameObject);
        }
    }
}