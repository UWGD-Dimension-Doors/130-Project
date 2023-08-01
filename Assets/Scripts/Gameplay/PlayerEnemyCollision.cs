using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
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

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            //is set to true if the player is touching the enemy from the x or y direction
            var willHurtEnemyY = player.Bounds.center.y >= enemy.Bounds.max.y || player.Bounds.center.y <= enemy.Bounds.max.y;
            var willHurtEnemyX = player.Bounds.center.x >= enemy.Bounds.max.x || player.Bounds.center.x <= enemy.Bounds.max.x;

            //is set to true if the player is the up to the size we want them to be to eat the enemy
            var willEatEnemy = enemy.deathPoint <= player.GetComponent<SpriteRenderer>().transform.localScale.x;

            if ((willHurtEnemyY && enemy.yDeath) || (willHurtEnemyX && enemy.xDeath))
            {
                if (willEatEnemy)
                {
                    var enemyHealth = enemy.GetComponent<Health>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.Decrement();
                        if (!enemyHealth.IsAlive)
                        {
                            Schedule<EnemyDeath>().enemy = enemy;
                            player.Bounce(2);
                        }
                        else
                        {
                            player.Bounce(7);
                        }
                    }
                    else
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        player.Bounce(2);
                    }
                    player.GetComponent<SpriteRenderer>().transform.localScale += new Vector3(0.2f, 0.2f, 0);
                }
                else 
                {
                    Schedule<PlayerDeath>();
                }
            }
            else
            {
                Schedule<PlayerDeath>();
            }
        }
    }
}