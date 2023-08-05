using Platformer.Mechanics;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="PlayerEnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        public override void Execute()
        {
            bool isCollisionY = player.Bounds.center.y >= enemy.Bounds.max.y || player.Bounds.center.y <= enemy.Bounds.max.y;
            bool isCollisionX = player.Bounds.center.x >= enemy.Bounds.max.x || player.Bounds.center.x <= enemy.Bounds.max.x;

            bool isCollision = isCollisionX || isCollisionY;

            bool canEatEnemy = player.GetComponent<SpriteRenderer>().transform.localScale.x >= enemy.transform.localScale.x;

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

            Schedule<PlayerAte>().enemy = enemy;
        }
    }
}