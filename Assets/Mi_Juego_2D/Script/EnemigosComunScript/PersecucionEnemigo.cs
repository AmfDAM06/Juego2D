using UnityEngine;

public class PersecucionEnemigo : MonoBehaviour
{
    public float velocidad = 3f;
    public float distanciaDeteccion = 10f; // Rango para empezar a perseguir

    private Transform jugador;
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject objJugador = GameObject.FindGameObjectWithTag("Player");

        if (objJugador != null)
        {
            jugador = objJugador.transform;
            Debug.Log("Enemigo: ¡He encontrado al jugador!");
        }
        else
        {
            Debug.LogError("Enemigo: NO encuentro al jugador. ¿Tiene el Tag 'Player' puesto?");
        }
    }
    void FixedUpdate()
    {
        if (jugador == null) return;

        // Calculamos la distancia
        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Si está dentro del rango, perseguimos
        if (distancia < distanciaDeteccion)
        {
            MoverHaciaJugador();
        }
        else
        {
            // Opcional: Detenerse si el jugador está lejos
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }

    void MoverHaciaJugador()
    {
        // Determinar dirección (-1 izquierda, 1 derecha)
        float direccionX = Mathf.Sign(jugador.position.x - transform.position.x);

        // Aplicar velocidad respetando la gravedad (Y) actual
        rb.linearVelocity = new Vector2(direccionX * velocidad, rb.linearVelocity.y);

        // Girar el sprite
        if ((direccionX > 0 && !mirandoDerecha) || (direccionX < 0 && mirandoDerecha))
        {
            Girar();
        }
    }

    void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}