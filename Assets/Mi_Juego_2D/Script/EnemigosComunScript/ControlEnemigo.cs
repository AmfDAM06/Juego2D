using UnityEngine;



public class ControlEnemigo : MonoBehaviour
{
    public Vector3 posicionFin;
    public float velocidad;

    private Vector3 posicionInicio;
    private GameObject enemy;
    private bool moviendoAFin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.parent.gameObject;
        posicionInicio = enemy.transform.position;
        moviendoAFin = true;

    }

    // Update is called once per frame
    void Update()
    {
        moverEnemigo();
    }

    private void moverEnemigo()
    {
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, posicionDestino, velocidad * Time.deltaTime);
        if(enemy.transform.position == posicionFin) moviendoAFin = false;
        if(enemy.transform.position == posicionInicio) moviendoAFin = true;

    }
}
