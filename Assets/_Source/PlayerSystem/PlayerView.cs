using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Coroutine RotateToDefaultCor;
        private CollisionDetector collisionDetector;
        public event System.Action OnDeath;
        public event System.Action OnReachFinish;
        private float distToGround;
        private IEnumerator RotateToDefaultCoroutine()
        {
            float time = 0;
            while (time < 1)
            {
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.identity, time);
                time += Time.deltaTime * 1.2f;
                yield return null;
            }
        }
        public void Fly(float flyingSpeed)
        {
            rb.AddForce(new Vector2(0,flyingSpeed), ForceMode2D.Impulse);
            rb.angularVelocity = 0f;
            if (RotateToDefaultCor != null)
            {
                StopCoroutine(RotateToDefaultCor);
            }
            RotateToDefaultCor = StartCoroutine(RotateToDefaultCoroutine());
        }
        public void Move(float movingSpeed)
        {
            float xMove = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(xMove, 0) * movingSpeed, ForceMode2D.Impulse);
            Rotate();
        }
        public void Rotate()
        {
            if(IsGrounded())
            {
                rb.angularVelocity += 1f;
            }
        }
        private void Death()
        {
            OnDeath?.Invoke();
        }
        private void ReachFinish()
        {
            OnReachFinish?.Invoke();
        }
        public void Construct(Rigidbody2D rb, float distToGround, CollisionDetector collisionDetector)
        {
            this.rb = rb;
            this.distToGround = distToGround;
            this.collisionDetector = collisionDetector;
            this.collisionDetector.OnDeath += Death;
            this.collisionDetector.OnReachFinish += ReachFinish;
        }
        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position,-Vector2.up, distToGround);
        }
    }
}
