using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public Transform puntoDeDisparo; // Un GameObject vacío hijo del jugador donde sale la bala
    public GameObject prefabBala;

    // Variables para PowerUps
    [HideInInspector] public bool disparoPotenciado = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Usualmente Ctrl izquierdo o Click
        {
            Disparar();
        }
    }

    void Disparar()
    {
        if (puntoDeDisparo == null || prefabBala == null) return;

        GameObject balaTemp = Instantiate(prefabBala, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Si tenemos el PowerUp de daño, modificamos la bala
        if (disparoPotenciado)
        {
            Bala scriptBala = balaTemp.GetComponent<Bala>();
            if (scriptBala != null)
            {
                scriptBala.dao *= 2; // Doble daño
                balaTemp.transform.localScale *= 1.5f; // Bala más grande visualmente
            }
        }
    }
}