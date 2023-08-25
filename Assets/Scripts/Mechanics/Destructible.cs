using Platformer.Mechanics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Destructible : MonoBehaviour
{

    public PlayerController player;
    public AudioClip destruction;

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
            AudioSource.PlayClipAtPoint(destruction, gameObject.transform.position);
            gameObject.SetActive(false);
        }
    }

    void ToggleShader()
    {
        if (!IsBreakable())
        {
            return;
        }

        gameObject.AddComponent<Light2D>();
        gameObject.GetComponent<Light2D>().intensity = 1;
        gameObject.GetComponent<Light2D>().color = Color.green;

        if (breakPoint >= 3f)
        {
            gameObject.GetComponent<Light2D>().pointLightOuterRadius = 3;
        }
    }

    public bool IsBreakable()
    {
        return player.GetComponent<SpriteRenderer>().transform.localScale.x >= breakPoint;
    }

}
