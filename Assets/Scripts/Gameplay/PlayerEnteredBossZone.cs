using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a BossZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredBossZone"></typeparam>
    public class PlayerEnteredBossZone : Simulation.Event<PlayerEnteredBossZone>
    {
        public BossZone bossZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            PlayBossSound();
        }

        private void PlayBossSound()
        {
            if (model.player.audioSource && bossZone.bossAudio)
            {
                model.player.audioSource.PlayOneShot(bossZone.bossAudio);
            }
        }

    }
}