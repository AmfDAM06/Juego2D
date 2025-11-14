using UnityEngine;

public class SaltoJugador : MonoBehaviour
{
    public int fuerzaSalto;

    private Rigidbody2D fisica;
    private bool entradaSalto;
    private GameObject jugador;
    private GameObject player_idle;

    public AudioClip saltoSfx;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = transform.parent.gameObject;
        player_idle = jugador.transform.Find("player-idle-1").gameObject;
        fisica = player_idle.GetComponent<Rigidbody2D>();
        audioSource = jugador.transform.Find("AudioSource").gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (entradaSalto == true)
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            entradaSalto = false;
            audioSource.PlayOneShot(saltoSfx);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tocarSuelo())
        {
            entradaSalto = true;
        }
    }

    private bool tocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(player_idle.transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

}
