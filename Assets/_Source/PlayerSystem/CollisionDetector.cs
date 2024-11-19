using PlayerSystem;
using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerSystem
{
    public class CollisionDetector : MonoBehaviour
    {
        private Rigidbody2D rb;
        private PlayerView view;
        private ScoreManager scoreManager;
        public event System.Action OnDeath;
        public event System.Action OnReachFinish;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                OnDeath?.Invoke();
                scoreManager.ResetScore();
                scoreManager.SaveScore();
            }
            else if (collision.gameObject.CompareTag("BigPowerup"))
            {
                if (gameObject.transform.localScale.x < 2)
                {
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.2f, gameObject.transform.localScale.y * 1.2f, 1);
                    rb.mass *= 1.2f;
                    scoreManager.AddToScore(scoreManager.PowerupScore);
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("SmallPowerup"))
            {
                if (gameObject.transform.localScale.x > 0.1f)
                {
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 0.8f, gameObject.transform.localScale.y * 0.8f, 1);
                    rb.mass *= 0.8f;
                    scoreManager.AddToScore(scoreManager.PowerupScore);
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("Falling"))
            {
                collision.rigidbody.constraints = RigidbodyConstraints2D.None;
            }
            else if (collision.gameObject.CompareTag("Finish"))
            {
                scoreManager.AddToScore(scoreManager.LevelFinishScore);
                scoreManager.AddToLevel();
                scoreManager.SaveScore();
                OnReachFinish?.Invoke();
            }
        }
        public void Construct(Rigidbody2D rb, PlayerView view, ScoreManager scoreManager)
        {
            this.rb = rb;
            this.view = view;
            this.scoreManager = scoreManager;
        }
    }
}
