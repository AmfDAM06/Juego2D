using UnityEngine;
using System.Collections;

public class PoderesJugador : MonoBehaviour
{
    private bool esInvencible = false;
    private DisparoJugador sistemaDisparo;

    void Start()
    {
        sistemaDisparo = GetComponent<DisparoJugador>();
    }

    public bool EsInvencible() { return esInvencible; }

    public void ActivarInvencibilidad(float duracion)
    {
        StartCoroutine(RutinaInvencibilidad(duracion));
    }

    public void ActivarDaoExtra(float duracion)
    {
        StartCoroutine(RutinaDanoExtra(duracion));
    }

    private IEnumerator RutinaInvencibilidad(float tiempo)
    {
        esInvencible = true;
        Debug.Log("¡Jugador Invencible!");
        // Aquí podrías cambiar el color del sprite a amarillo, por ejemplo
        yield return new WaitForSeconds(tiempo);
        esInvencible = false;
        Debug.Log("Fin Invencibilidad");
    }

    private IEnumerator RutinaDanoExtra(float tiempo)
    {
        if (sistemaDisparo != null) sistemaDisparo.disparoPotenciado = true;
        Debug.Log("¡Daño Doble Activado!");
        yield return new WaitForSeconds(tiempo);
        if (sistemaDisparo != null) sistemaDisparo.disparoPotenciado = false;
        Debug.Log("Fin Daño Doble");
    }
}