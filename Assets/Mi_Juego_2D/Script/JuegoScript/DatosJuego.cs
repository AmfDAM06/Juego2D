using UnityEngine;

public class DatosJuego : MonoBehaviour
{
    private int puntuacion;
    private bool ganado;

    public int Puntuacion { get => puntuacion; set => puntuacion = value; }
    public bool Ganado { get => ganado; set => ganado = value; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int numInstancias = Object.FindObjectsByType<DatosJuego>(FindObjectsSortMode.None).Length;

        if (numInstancias != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
