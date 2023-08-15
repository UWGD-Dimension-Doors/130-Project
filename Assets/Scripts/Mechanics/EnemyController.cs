using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        SpriteRenderer spriteRenderer;

        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        void Update()
        {
            if (path != null)
            {
                mover ??= path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
                control.move.y = Mathf.Clamp(mover.Position.y - transform.position.y, -1, 1);
            }

            ToggleDangerShader();
        }

        void ToggleDangerShader()
        {
            Color transparent = new(1, 1, 1, 1);

            if (IsDangerous())
            {
                spriteRenderer.material.SetColor("_Color", Color.red);
            } else if (spriteRenderer.material.color != transparent)
            {
                spriteRenderer.material.SetColor("_Color", transparent);
            }
        }

        public bool IsDangerous()
        {
            float enemyScale = spriteRenderer.transform.localScale.x;
            float playerScale = model.player.GetComponent<SpriteRenderer>().transform.localScale.x;

            return enemyScale > playerScale;
        }
    }
}