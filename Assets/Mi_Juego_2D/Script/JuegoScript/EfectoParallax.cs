using UnityEngine;
using UnityEngine.Rendering;

public class EfectoParallax : MonoBehaviour
{
    public float efectoParallax;
    private Transform camara;
    private Vector3 ultimaPosicionCamara;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        camara = Camera.main.transform;
        ultimaPosicionCamara = camara.position;
        
    }

    private void LateUpdate()
    {
        
        Vector3 movimientoFondo = camara.position - ultimaPosicionCamara;
        transform.position += new Vector3(movimientoFondo.x * efectoParallax, movimientoFondo.y, 0);
        ultimaPosicionCamara = camara.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
