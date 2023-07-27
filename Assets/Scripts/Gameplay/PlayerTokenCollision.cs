using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>


    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        // Constants affecting player sprite scaling.
        private Vector3 playerScaleChange = new(0.02f, 0.02f, 0.0f);

        public override void Execute()
        {

            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);

            // Rescale the player sprite when a coin is collected.
            player.GetComponent<SpriteRenderer>().transform.localScale += playerScaleChange;

            // Increment the score when a coin is collected.
            Score.UpdateScore();
            Debug.Log("Player collected a token! Score: " + Score.GetScore());
       }
    }
}
