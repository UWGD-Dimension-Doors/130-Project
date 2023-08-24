using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a BossZone, usually used to end the current game level.
    /// </summary>
    public class BossZone : MonoBehaviour
    {
        public AudioClip bossAudio;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredBossZone>();
                ev.bossZone = this;
            }
        }
    }
}