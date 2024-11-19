using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class BindToScreenSpace : MonoBehaviour
    {
        private Camera _camera;
        private Vector2 _screenMin;
        private Vector2 _screenMax;
        private float _objectWidth;
        private float _objectHeight;

        void Start()
        {
            _camera = Camera.main;
            _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
            _objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        }

        void LateUpdate()
        {
            _screenMin = _camera.ViewportToWorldPoint(Vector2.zero);
            _screenMax = _camera.ViewportToWorldPoint(Vector2.one);
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, _screenMin.x + _objectWidth, _screenMax.x - _objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, _screenMin.y + _objectHeight, _screenMax.y - _objectHeight);
            transform.position = viewPos;
        }
    }
}
