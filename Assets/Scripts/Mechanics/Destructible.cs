using Platformer.Mechanics;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public PlayerController player;

    //minimum size to break object
    public float breakPoint = 1.5f;

    private void Update()
    {
        ToggleShader();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (IsBreakable())
        {
            gameObject.SetActive(false);
        }
    }

    void ToggleShader()
    {
        if (IsBreakable())
        {
           gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.yellow);
        }
    }

    public bool IsBreakable()
    {
        return player.GetComponent<SpriteRenderer>().transform.localScale.x >= breakPoint;
    }

}
