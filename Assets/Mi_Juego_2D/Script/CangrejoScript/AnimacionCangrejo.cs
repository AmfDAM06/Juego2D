using UnityEngine;

public class AnimacionCangrejo : MonoBehaviour
{
    private GameObject cangrejo;
    private GameObject crab_idle; // El hijo que tiene el Sprite y el Animator
    private Animator animacion;
    private Vector3 ultimaPosicion;

    void Start()
    {
        cangrejo = transform.parent.gameObject;

        // Buscamos al hijo visual (asegúrate de que se llama así en la jerarquía)
        crab_idle = cangrejo.transform.Find("crab-idle-1").gameObject;

        if (crab_idle != null)
        {
            animacion = crab_idle.GetComponent<Animator>();
            ultimaPosicion = crab_idle.transform.position;
        }
        else
        {
            Debug.LogError("No encuentro el hijo 'crab-idle-1' en el enemigo antiguo.");
        }
    }

    void Update()
    {
        if (animacion != null)
        {
            AnimarCangrejo();
        }
    }

    private void AnimarCangrejo()
    {
        Vector3 posicionActual = crab_idle.transform.position;

        // Calculamos cuánto se ha movido desde el último frame
        float diferenciaX = Mathf.Abs(posicionActual.x - ultimaPosicion.x);

        // Si se mueve algo (más de 0.001 unidades), activamos "andando"
        if (diferenciaX > 0.001f)
        {
            animacion.SetBool("CangrejoAndando", true);
        }
        else
        {
            // Si está quieto, desactivamos "andando" para que vuelva a Idle
            animacion.SetBool("CangrejoAndando", false);
        }

        // ¡IMPORTANTE! Actualizamos la posición para la siguiente comprobación
        ultimaPosicion = posicionActual;
    }
}