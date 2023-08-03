using Platformer.Core;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDeath : MonoBehaviour
{

    public PlayerController player;
    //minum size to destroy hazard
    public float livePoint = 1.5f;

    PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    void OnCollisionEnter2D(Collision2D col)
    {
        if (player.GetComponent<SpriteRenderer>().transform.localScale.x >= livePoint)
        {
            this.gameObject.SetActive(false);
            Debug.Log("Breaking");
        }
        else
        {
            //kills player
            var player = model.player;
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                Simulation.Schedule<PlayerSpawn>(2);
            }
        }
    }
}
