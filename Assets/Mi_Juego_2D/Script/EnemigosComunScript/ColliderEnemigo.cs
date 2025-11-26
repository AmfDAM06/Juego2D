using UnityEngine;

public class ColliderEnemigo : MonoBehaviour
{
    // Usamos OnCollisionEnter2D porque ahora ambos (jugador y enemigo) son sólidos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectamos si choca con el Jugador
        if (collision.gameObject.CompareTag("Player_Idle") || collision.gameObject.CompareTag("Player"))
        {
            // Buscamos el script de poderes para ver si es invencible
             PoderesJugador poderes = collision.gameObject.GetComponent<PoderesJugador>();

            //Si es invencible, no hacemos daño y salimos
            if (poderes != null && poderes.EsInvencible())
            {
               return;
            }

            Debug.Log("El enemigo ha golpeado al jugador");

            // Llamamos a quitar vida
            ControlJuego control = GameObject.FindGameObjectWithTag("ControlJuego").GetComponent<ControlJuego>();
            if (control != null)
            {
                control.QuitarVida();
            }
        }
    }
}