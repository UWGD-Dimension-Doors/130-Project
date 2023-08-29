using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        public AudioClip victoryAudio;
        private bool playerEnteredVictoryZone = false;
        private readonly float fadeOutSpeed = 25;

        private void Update()
        {
            if (!playerEnteredVictoryZone)
            {
                return;
            }

            FadeToColor();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
                playerEnteredVictoryZone = true;
            }
        }

        void FadeToColor()
        {
            GameObject totem = GameObject.Find("Totem");
            if (!totem)
            {
                return;
            }

            Light2D totemLight = totem.GetComponentInChildren<Light2D>();
            if (!totemLight)
            {
                return;
            }

            totemLight.intensity = Mathf.MoveTowards(totemLight.intensity, float.MaxValue, fadeOutSpeed * Time.deltaTime);
            totemLight.pointLightOuterRadius = Mathf.MoveTowards(totemLight.pointLightOuterRadius, float.MaxValue, fadeOutSpeed * Time.deltaTime);
            totemLight.pointLightInnerRadius = Mathf.MoveTowards(totemLight.pointLightInnerRadius, float.MaxValue, fadeOutSpeed * Time.deltaTime); ;
        }

    }
}