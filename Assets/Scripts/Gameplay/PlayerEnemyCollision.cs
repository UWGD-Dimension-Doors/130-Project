using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        public override void Execute()
        {
            // True if the player is touching the enemy from the x or y direction
            bool isCollisionY = player.Bounds.center.y >= enemy.Bounds.max.y || player.Bounds.center.y <= enemy.Bounds.max.y;
            bool isCollisionX = player.Bounds.center.x >= enemy.Bounds.max.x || player.Bounds.center.x <= enemy.Bounds.max.x;

            bool isCollision = isCollisionX || isCollisionY;

            //is set to true if the player is the up to the size we want them to be to eat the enemy
            bool canEatEnemy = enemy.deathPoint <= player.GetComponent<SpriteRenderer>().transform.localScale.x;

            if (!isCollision)
            {
                return;
            }

            if (!canEatEnemy)
            {
                Schedule<PlayerDeath>();
                return;
            }

            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null && enemyHealth.IsAlive)
            {
                player.Bounce(7);
                return;
            }

            Schedule<EnemyDeath>().enemy = enemy;
            player.Bounce(2);

            player.FattenPlayerAndIncrementScore(2);
        }
    }
}