using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player eats a token or enemy. Handles related side effects.
    /// </summary>
    /// <typeparam name="PlayerAte"></typeparam>
    public class PlayerAte : Simulation.Event<PlayerAte>
    {
        public EnemyController enemy;
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Vector3 playerScaleChange = new(0.1f, 0.1f, 0.0f);

        public override void Execute()
        {
            PlayerController player = model.player;

            // Prey might be an enemy or a token.
            float preyLevel = 1;

            if (enemy != null)
            {
                preyLevel = enemy.GetComponent<SpriteRenderer>().transform.localScale.x;
            }
 
            Vector3 adjustedPlayerScaleChange = playerScaleChange * preyLevel;

            // Scale up the player sprite after eating.
            player.GetComponent<SpriteRenderer>().transform.localScale += adjustedPlayerScaleChange;

            View.ZoomOut.IncrementalZoomOut();

            // Increment the score after eating.
            ScoreController.UpdateScore(preyLevel);
        }

    }
}