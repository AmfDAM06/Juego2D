using UnityEngine;

public class ContolAnimacionJugador : MonoBehaviour
{
    private GameObject jugador;
    private GameObject player_idle;
    private Animator animacion;
    private Rigidbody2D fisica;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        jugador = transform.parent.gameObject;
        player_idle = jugador.transform.Find("player-idle-1").gameObject;
        animacion = player_idle.GetComponent<Animator>();
        fisica = player_idle.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animarJugador();
    }

    private void animarJugador()
    {
        // Jugador Saltar
        if (!tocarSuelo())
        { animacion.Play("jugadorSaltando"); }
        else
        {
            //Jugador Corriendo
            if (fisica.linearVelocity.x != 0 && fisica.linearVelocity.y == 0)
                animacion.Play("jugadorCorriendo");
            //Jugador Parado
            if (fisica.linearVelocity.x == 0 && fisica.linearVelocity.y == 0)
                animacion.Play("jugadorParado");
        }
    }

    private bool tocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(player_idle.transform.position + new Vector3(0, -1.8f, 0), Vector2.down, 0.2f);

        //Dubujar rayo

        Debug.DrawRay(player_idle.transform.position + new Vector3(0, -1.8f, 0), Vector3.down * 2, Color.green, 2f);

        return toca.collider != null;
    }
}
