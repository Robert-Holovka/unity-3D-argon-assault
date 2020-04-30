using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    internal class ScoreDisplay : MonoBehaviour
    {
        private int score = default;
        private Text scoreText = default;

        private void Awake()
        {
            scoreText = GetComponent<Text>();
        }

        void Start()
        {
            scoreText.text = score.ToString();
        }

        public void OnEnemyHit(int score)
        {
            this.score += score;
            scoreText.text = score.ToString();
        }
    }
}
