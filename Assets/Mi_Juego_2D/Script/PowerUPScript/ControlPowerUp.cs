using UnityEngine;

public class ControlPowerUp : MonoBehaviour
{
    public AudioClip recolectarSfx;
    private AudioSource audioSource;
    private GameObject player;
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
            player = collision.transform.parent.gameObject;            
            GameObject.FindGameObjectWithTag
                ("ControlJuego").gameObject.GetComponent<ControlJuego>().IncrementarPuntos(100);
            Destroy(gameObject);
            audioSource = player.transform.Find("AudioSource").gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(recolectarSfx);
        }
    }
}
