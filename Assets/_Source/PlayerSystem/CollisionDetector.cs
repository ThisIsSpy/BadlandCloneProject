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
        private float increaseMult;
        private float decreaseMult;
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
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * increaseMult, gameObject.transform.localScale.y * increaseMult, 1);
                    rb.mass *= increaseMult;
                    scoreManager.AddToScore(scoreManager.PowerupScore);
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.CompareTag("SmallPowerup"))
            {
                if (gameObject.transform.localScale.x > 0.1f)
                {
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * decreaseMult, gameObject.transform.localScale.y * decreaseMult, 1);
                    rb.mass *= decreaseMult;
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
        public void Construct(Rigidbody2D rb, PlayerView view, ScoreManager scoreManager, float increaseMult, float decreaseMult)
        {
            this.rb = rb;
            this.view = view;
            this.scoreManager = scoreManager;
            this.increaseMult = increaseMult;
            this.decreaseMult = decreaseMult;
        }
    }
}
