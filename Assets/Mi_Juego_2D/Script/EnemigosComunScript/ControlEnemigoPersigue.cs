using UnityEngine;



public class ControlEnemigoPersigue : MonoBehaviour
{
    public float velocidad;

    private GameObject enemy;

    private GameObject jugador;

    public Vector3 posicionDestino;
    public Vector3 posicionEnemigo;
    public Vector3 posicionJugador;
    private Rigidbody2D fisicaJugador;

    public float minimoX;
    public float maximoX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        fisicaJugador = jugador.GetComponentInChildren<Rigidbody2D>();
        posicionJugador = jugador.transform.position;
        enemy = transform.parent.gameObject;
        Debug.Log("Posicion jugador: " + posicionJugador);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        moverEnemigo();
        posicionJugador = fisicaJugador.position;
        Debug.Log("Posicion jugador: " + posicionJugador);

    }

    private void moverEnemigo()
    {
        float x = posicionJugador.x < minimoX ? minimoX : posicionJugador.x > maximoX ? maximoX : posicionJugador.x;
        posicionDestino = new Vector3(x, enemy.transform.position.y, enemy.transform.position.z);
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, posicionDestino, velocidad * Time.deltaTime);
    }
}
