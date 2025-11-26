using UnityEngine;

public enum TipoPowerUp
{
    Puntos,
    Invencibilidad,
    DanoExtra
}

public class ControlPowerUp : MonoBehaviour
{
    public TipoPowerUp tipo;
    public float duracionEfecto = 5f; // Solo para invencibilidad o daño
    public AudioClip recolectarSfx;

    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar si choca con el Jugador (asumiendo que la física está en un hijo o padre)
        // Buscamos el componente PoderesJugador en la jerarquía
        PoderesJugador poderes = collision.transform.GetComponentInParent<PoderesJugador>();

        // Nota: Si collision es el "player-idle-1", GetComponentInParent buscará en el padre "Jugador"
        if (poderes == null) poderes = collision.transform.GetComponent<PoderesJugador>();

        if (poderes != null)
        {
            // Lógica según el tipo
            switch (tipo)
            {
                case TipoPowerUp.Puntos:
                    GameObject.FindGameObjectWithTag("ControlJuego")
                        .GetComponent<ControlJuego>().IncrementarPuntos(100);
                    break;

                case TipoPowerUp.Invencibilidad:
                    poderes.ActivarInvencibilidad(duracionEfecto);
                    break;

                case TipoPowerUp.DanoExtra:
                    poderes.ActivarDaoExtra(duracionEfecto);
                    break;
            }

            // Sonido
            AudioSource audio = poderes.transform.Find("AudioSource")?.GetComponent<AudioSource>();
            if (audio != null && recolectarSfx != null)
            {
                audio.PlayOneShot(recolectarSfx);
            }

            Destroy(gameObject);
        }
    }
}