using System;
using System.Collections;
using UnityEngine;

namespace ObserverPattern
{
    /// <summary>
    /// Demonstrates a simple observer for the Observer Pattern example.
    /// <br/>
    /// This class represents the <b>Subscriber</b> that would react to a published event (e.g., level up).
    /// It simulates a health system that drains over time and can be reset when notified.
    /// <br/>
    /// Note: This setup is for educational purposes only and not optimized for production use.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// The Level component that will trigger a level-up event.
        /// </summary>
        [Tooltip("The Level component that will trigger a level-up event.")]
        [SerializeField] private Level _level;
        
        /// <summary>
        /// The maximum health of the character.
        /// </summary>
        [Tooltip("The maximum health of the character.")]
        [SerializeField] private int _maxHealth = 100;

        /// <summary>
        /// The amount of health drained per second.
        /// </summary>
        [Tooltip("The amount of health drained per second.")]
        [SerializeField] private int _drainPerSecond = 2;

        /// <summary>
        /// The character's current health value.
        /// </summary>
        public float CurrentHealth { get; private set; }

        /// <summary>
        /// Delay used to simulate gradual health drain.
        /// </summary>
        private readonly WaitForSeconds _wait = new(1f);

        /// <summary>
        /// Initializes the health and starts the drain coroutine.
        /// </summary>
        private void Awake()
        {
            ResetHealth();
            StartCoroutine(HealthDrain());
        }

        /// <summary>
        /// Ensures that the Level component is not null before subscribing to its event.
        /// </summary>
        private void OnEnable()
        {
            if (_level == null) return;
            _level.OnLevelUp += ResetHealth;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnDisable()
        {
            if (_level == null) return;
            _level.OnLevelUp -= ResetHealth;
        }

        /// <summary>
        /// Resets the current health to maximum value.
        /// Typically called when a level-up event occurs.
        /// </summary>
        public void ResetHealth()
        {
            CurrentHealth = _maxHealth;
        }

        /// <summary>
        /// Coroutine that continuously drains the health value over time.
        /// </summary>
        /// <returns>An IEnumerator for Unity's coroutine system.</returns>
        private IEnumerator HealthDrain()
        {
            // Simulate slow health loss over time
            while (CurrentHealth > 0)
            {
                CurrentHealth -= _drainPerSecond;
                yield return _wait;
            }

            // In a game, this could trigger a "death" event or animation
        }
    }
}
