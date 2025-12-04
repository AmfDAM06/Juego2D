using UnityEngine;

public class AnimacionCangrejo : MonoBehaviour
{
    private GameObject cangrejo;
    private GameObject crab_idle;
    private Animator animacion;
    private Vector3 ultimaPosicion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cangrejo = transform.parent.gameObject;
        crab_idle = cangrejo.transform.Find("crab-idle-1").gameObject;
        animacion = crab_idle.GetComponent<Animator>();
        ultimaPosicion = crab_idle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AnimarCangrejo();
    }

    private void AnimarCangrejo()
    {
        Vector3 posicionActual = crab_idle.transform.position;
        float diferenciaX = posicionActual.x - ultimaPosicion.x;

        if (diferenciaX > 0.001f || diferenciaX < -0.001f)
            animacion.Play("CangrejoAndando");
    }
}
