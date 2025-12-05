using UnityEngine;

public class ControlEnemigoPersigue : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad;
    public float minimoX;
    public float maximoX;

    [Header("Configuración de IA")]
    public float distanciaVision = 5.0f;

    [Header("Referencias")]
    private GameObject enemy;
    private Transform objetivoA_Perseguir;
    private SpriteRenderer spriteRenderer;
    private Animator miAnimator;

    private Vector3 posicionDestino;

    void Start()
    {
        enemy = transform.parent.gameObject;

        GameObject jugadorHijo = GameObject.FindGameObjectWithTag("Player_Idle");

        if (jugadorHijo != null)
        {
            objetivoA_Perseguir = jugadorHijo.transform;
        }
        else
        {
            Debug.LogError("ERROR: No encuentro 'Player_Idle'.");
        }

        spriteRenderer = enemy.GetComponentInChildren<SpriteRenderer>();
        miAnimator = enemy.GetComponentInChildren<Animator>();

        if (miAnimator == null)
        {
            Debug.LogError("¡SOCORRO! No encuentro el componente Animator en el enemigo ni en sus hijos.");
        }
        else
        {
            Debug.Log("¡Genial! He encontrado el Animator y está listo.");
        }
    }

    void Update()
    {
        if (objetivoA_Perseguir == null) return;

        float distanciaActual = Vector3.Distance(enemy.transform.position, objetivoA_Perseguir.position);

        if (distanciaActual < distanciaVision)
        {
            moverEnemigo();
            gestionarOrientacion();

            if (miAnimator != null) miAnimator.SetBool("CangrejoAndando", true);
        }
        else
        {
            if (miAnimator != null) miAnimator.SetBool("CangrejoAndando", false);
        }
    }

    private void moverEnemigo()
    {
        float xClamped = Mathf.Clamp(objetivoA_Perseguir.position.x, minimoX, maximoX);
        posicionDestino = new Vector3(xClamped, enemy.transform.position.y, enemy.transform.position.z);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, posicionDestino, velocidad * Time.deltaTime);
    }

    private void gestionarOrientacion()
    {
        if (posicionDestino.x > enemy.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (posicionDestino.x < enemy.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (enemy != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(enemy.transform.position, distanciaVision);
        }
    }
}