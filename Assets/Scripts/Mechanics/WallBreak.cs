using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{

    public PlayerController player;
    //minimum size to break object
    public float breakPoint = 1.5f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (player.GetComponent<SpriteRenderer>().transform.localScale.x >= breakPoint)
        {
            this.gameObject.SetActive(false);
            Debug.Log("Breaking");
        }
        else
        {
            Debug.Log("Hit Detected");
        }
    }
}
