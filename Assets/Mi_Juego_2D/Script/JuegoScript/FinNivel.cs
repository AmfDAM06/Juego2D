using TMPro;
using UnityEngine;

public class FinNivel : MonoBehaviour
{
    public TextMeshProUGUI mensajeFinalTexto;
    private DatosJuego datosJuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        datosJuego = GameObject.Find("DatosJuego").GetComponent<DatosJuego>();
        string mensajeFinal = (datosJuego.Ganado) ? "HA GANADO!!" : "HA PERDIDO";
        if (datosJuego.Ganado) mensajeFinal += "Puntuación: " + datosJuego.Puntuacion;
        mensajeFinalTexto.text = mensajeFinal;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
