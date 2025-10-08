using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ObserverPattern
{
    /// <summary>
    /// Demonstrates a simple publisher for the Observer Pattern example.
    /// <br/>
    /// This class simulates a leveling system that gains experience over time.
    /// It represents the <b>Publisher</b> or <b>Subject</b> that would notify observers when the level changes.
    /// <br/>
    /// Note: This example is intentionally simplified for demonstration purposes and
    /// not intended for production use.
    /// </summary>
    public class Level : MonoBehaviour
    {
        /// <summary>
        /// The number of experience points required to reach the next level.
        /// </summary>
        [Tooltip("The number of experience points required to reach the next level.")]
        [SerializeField] private int _pointsToLevelUp = 100;
        
        /// <summary>
        /// Unity event that is invoked when the character levels up.
        /// </summary>
        [SerializeField] private UnityEvent _onLevelUp;
        
        /// <summary>
        /// Level up delegate.
        /// </summary>
        public delegate void LevelUpDelegate(int newLevel);
        
        /// <summary>
        /// Level up event.
        /// </summary>
        public event LevelUpDelegate OnLevelUp;

        /// <summary>
        /// The current total experience points accumulated by the character.
        /// </summary>
        public int ExperiencePoints { get; private set; }

        /// <summary>
        /// The current level of the character, calculated by dividing total experience by points per level.
        /// </summary>
        public int CurrentLevel => ExperiencePoints / _pointsToLevelUp;

        /// <summary>
        /// A delay used to simulate experience gain over time.
        /// </summary>
        private readonly WaitForSeconds _wait = new(0.2f);

        /// <summary>
        /// Unity coroutine that continuously adds experience points to simulate gameplay.
        /// </summary>
        /// <returns>An IEnumerator for Unity's coroutine system.</returns>
        private IEnumerator Start()
        {
            // Continuously loop to simulate leveling over time
            while (true)
            {
                yield return _wait;
                GainExperience(10); // Add 10 XP every 0.2 seconds
            }
        }

        /// <summary>
        /// Adds the specified number of experience points to the character.
        /// </summary>
        /// <param name="amount">The number of experience points to add.</param>
        private void GainExperience(int amount)
        {
            var previousLevel = CurrentLevel;

            ExperiencePoints += amount;

            // In a full implementation, this is where you'd notify observers (e.g., OnLevelUp event)

            if (CurrentLevel <= previousLevel) return;
            _onLevelUp?.Invoke();
            OnLevelUp?.Invoke(CurrentLevel);
        }
    }
}
