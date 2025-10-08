using System.Collections;
using UnityEngine;

namespace ObserverPattern
{
    /// <summary>
    /// A simple in-editor debug monitor that prints current experience, level, and health to the console.
    /// <br/>
    /// This demonstrates how an external observer (like UI or debugging tools)
    /// can monitor data updates without interfering with the logic itself.
    /// <br/>
    /// Note: This is purely for demonstration of the pattern and not production code.
    /// </summary>
    [RequireComponent(typeof(Health), typeof(Level))]
    public class Debugger : MonoBehaviour
    {
        /// <summary>
        /// Delay used between console print updates.
        /// </summary>
        private readonly WaitForSeconds _wait = new(1f);

        /// <summary>
        /// Unity coroutine that prints Health and Level data to the Console every second.
        /// </summary>
        /// <returns>An IEnumerator for Unity's coroutine system.</returns>
        public IEnumerator Start()
        {
            // Retrieve references to attached components
            var health = GetComponent<Health>();
            var level = GetComponent<Level>();

            // Loop forever, printing out runtime state values
            while (true)
            {
                yield return _wait;

                Debug.Log(
                    $"Exp: {level!.ExperiencePoints},  Level: {level!.CurrentLevel},  Health: {health!.CurrentHealth}"
                );
            }
        }
    }
}