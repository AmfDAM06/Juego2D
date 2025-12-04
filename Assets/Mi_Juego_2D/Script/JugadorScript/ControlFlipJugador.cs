using UnityEngine;

public class ControlFlipJugador : MonoBehaviour
{

    private Rigidbody2D physic;
    private SpriteRenderer sprite;

    private GameObject player;
    private GameObject player_idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        player = transform.parent.gameObject;
        player_idle = player.transform.Find("player-idle-1").gameObject;
        physic = player_idle.GetComponent<Rigidbody2D>();
        sprite = player_idle.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (physic.linearVelocity.x > 0) sprite.flipX = false;
        if (physic.linearVelocity.x < 0) sprite.flipX = true;
    }
}
