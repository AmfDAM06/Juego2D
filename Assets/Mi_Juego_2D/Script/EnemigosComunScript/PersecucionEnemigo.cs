using UnityEngine;

public class PersecucionEnemigo : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 3f;
    public float distanciaDeteccion = 15f;
    public float distanciaParada = 1.2f; // Aumentado un poco para evitar choques
    public bool spriteMiraIzquierda = true; // Marcado por defecto para tu cangrejo

    private Transform jugador;
    private Rigidbody2D rb;

    void Start()
    {
        // Opción B: Busca el RB en el padre
        rb = GetComponentInParent<Rigidbody2D>();
        GameObject objJugador = GameObject.FindGameObjectWithTag("Player");
        if (objJugador != null) jugador = objJugador.transform;
    }

    void FixedUpdate()
    {
        if (jugador == null || rb == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Solo nos movemos si estamos cerca pero no ENCIMA del jugador
        if (distancia < distanciaDeteccion && distancia > distanciaParada)
        {
            // 1. Calcular dirección (-1 izquierda, 1 derecha)
            float dirX = Mathf.Sign(jugador.position.x - transform.position.x);

            // 2. Mover física
            rb.linearVelocity = new Vector2(dirX * velocidad, rb.linearVelocity.y);

            // 3. Orientación visual (Girar padre)
            // Si el sprite original mira a la Izquierda:
            // - Para ir a la derecha (1) necesitamos escala X = -1 (invertir)
            // - Para ir a la izquierda (-1) necesitamos escala X = 1 (normal)
            float escalaX = (spriteMiraIzquierda) ? -dirX : dirX;

            transform.parent.localScale = new Vector3(escalaX, 1, 1);
        }
        else
        {
            // Frenar si estamos muy cerca o muy lejos
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}