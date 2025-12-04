using UnityEngine;
using TMPro;
public class HUD_Control : MonoBehaviour
{
    public TextMeshProUGUI numVidas;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI tiempoEmpleado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumVidas(int vidas)
    {
        numVidas.text = "Número de Vidas: " + vidas; 
    }

    public void setPuntuacion(int puntos)
    {
        puntuacion.text = "Puntuación: " + puntos;
    }

    public void setTiempoEmpleado(int tiempo)
    {
        tiempoEmpleado.text = "Tiempo: " + tiempo;
    }
}
