using UnityEngine;

public class ColliderEnemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Idle"))
        {
            Debug.Log("Toca enemigo");
            GameObject.FindGameObjectWithTag("ControlJuego").GetComponent<ControlJuego>().QuitarVida();
        }
    }
}
