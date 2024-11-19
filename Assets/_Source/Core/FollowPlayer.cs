using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core
{
    public class FollowPlayer : MonoBehaviour
    {
        private Object player;
        private bool isConstruct;

        private void Start()
        {
            isConstruct = false;
        }
        private void Update()
        {
            if (isConstruct && player != null)
            {
                Follow();
            }
        }
        public void Construct(Object player)
        {
            this.player = player;
            isConstruct = true;
        }
        private void Follow()
        {
            Vector3 oldPos = transform.position;
            Vector3 newPos = player.GameObject().transform.position;
            if (newPos.x < oldPos.x)
            {
                transform.position = new Vector3(transform.position.x, 0, -1);
            }
            else
            {
                transform.position = new Vector3(player.GameObject().transform.position.x, 0, -1);
            }
        }
    }
}
