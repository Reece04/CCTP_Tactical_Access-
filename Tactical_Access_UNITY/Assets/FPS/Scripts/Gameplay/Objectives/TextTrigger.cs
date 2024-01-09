using System.Collections;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class TextTrigger : TextManager
    {

        [Tooltip("Time before the object is destroyed after becoming visible")]
        public float DestroyDelay = 5.0f;

        protected override void Start()
        {
            base.Start();
            StartCoroutine(DestroyAfterDelay());
        }

        // Coroutine to destroy the object after a delay
        private IEnumerator DestroyAfterDelay()
        {
            yield return new WaitForSeconds(DestroyDelay);

            // Destroy the GameObject after the specified delay
            Destroy(gameObject);
        }
    }

}