using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    public int dao = 1;
    public float tiempoDeVida = 2f; // Se destruye sola si no toca nada

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // La bala avanza hacia la derecha relativa de su propia rotación
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con un enemigo
        if (collision.CompareTag("Enemigo"))
        {
            // Buscamos si tiene script de vida (ver punto siguiente)
            VidaEnemigo vida = collision.GetComponent<VidaEnemigo>();
            if (vida != null)
            {
                vida.RecibirDano(dao);
            }
            else
            {
                // Si no tiene script de vida, lo destruimos directamente
                Destroy(collision.gameObject);
            }
            Destroy(gameObject); // Destruir la bala
        }
        // Si choca con el suelo o paredes (Asumiendo capa "Suelo")
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}