using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone>
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;

            PlayVictorySound();

            StartVictoryScene victoryScene = GameObject.Find("Victory").GetComponent<StartVictoryScene>();
            if (victoryScene != null)
            {
                victoryScene.StartAfterDelay();
            }
        }

        private void PlayVictorySound()
        {
            if (model.player.audioSource && victoryZone.victoryAudio)
            {
                model.player.audioSource.PlayOneShot(victoryZone.victoryAudio);
            }
        }

    }
}