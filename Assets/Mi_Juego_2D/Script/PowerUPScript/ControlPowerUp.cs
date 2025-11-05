using UnityEngine;

public class ControlPowerUp : MonoBehaviour
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
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("Toca PowerUp");
            GameObject.FindGameObjectWithTag
                ("ControlJuego").gameObject.GetComponent<ControlJuego>().IncrementarPuntos(100);
            Destroy(gameObject);
        }
    }
}
