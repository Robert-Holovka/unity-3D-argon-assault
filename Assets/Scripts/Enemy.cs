using UnityEngine;

namespace Scripts
{
    internal class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject deathFX;
        [SerializeField] Transform spawnedAtRuntimeParent;

        [SerializeField] int scorePerHit = 12;
        [SerializeField] int hits = 1;

        private ScoreDisplay scoreBoard;

        private void Start()
        {
            scoreBoard = FindObjectOfType<ScoreDisplay>();
            AddBoxCollider();
        }

        private void AddBoxCollider()
        {
            BoxCollider collider = gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = false;
        }

        private void OnParticleCollision(GameObject other)
        {
            scoreBoard.OnEnemyHit(scorePerHit);
            hits--;

            if (hits <= 0)
            {
                KillEnemy();
            }
        }

        private void KillEnemy()
        {
            GameObject deathVFX = Instantiate(deathFX, transform.position, Quaternion.identity);
            deathVFX.transform.parent = spawnedAtRuntimeParent;
            Destroy(gameObject);
        }
    }
}