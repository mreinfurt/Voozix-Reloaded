﻿using System;
using UnityEngine;
using Screen = Utility.Screen;

namespace Entities
{
    public class ClampToScreenBounds : MonoBehaviour
    {
        /// <summary>
        /// Gets called whenever the object hits the screen bounds.
        /// Vector2 is a directional vector showing in which way the bounds were hit
        /// </summary>
        public Action<Vector2> OnHitScreenBounds = vector2 => { };

        private void Start()
        {
        }

        private void Update()
        {
            var newPosition = this.transform.position;
            var screenBounds = Screen.GetScreenSpaceBounds();

            if (newPosition.x < screenBounds.x || newPosition.x > screenBounds.x + screenBounds.width)
            {
                newPosition.x = Mathf.Clamp(newPosition.x, screenBounds.x, screenBounds.x + screenBounds.width);
                this.OnHitScreenBounds.Invoke(new Vector2(1, 0));
            }

            if (newPosition.y < screenBounds.y || newPosition.y > screenBounds.y + screenBounds.height)
            {
                newPosition.y = Mathf.Clamp(newPosition.y, screenBounds.y, screenBounds.y + screenBounds.height);
                this.OnHitScreenBounds.Invoke(new Vector2(0, 1));
            }

            this.transform.position = newPosition;
        }
    }
}