using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int saludMaxima = 2;
    private int saludActual;

    void Start()
    {
        saludActual = saludMaxima;
    }

    public void RecibirDano(int cantidad)
    {
        saludActual -= cantidad;
        if (saludActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Aquí puedes instanciar partículas de explosión o sonidos
        Destroy(gameObject);
    }
}