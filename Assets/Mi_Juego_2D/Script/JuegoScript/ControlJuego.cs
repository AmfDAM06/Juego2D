using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;


public class ControlJuego : MonoBehaviour
{
    public Canvas canvas;
    private HUD_Control hud;
    public int numVidas;
    public int puntuacion;
    public int tiempoNivel;

    private int tiempoInicio;
    private int tiempoEmpleado;
    private bool vulnerable;
    private GameObject jugador;
    private GameObject player_idle;
    private SpriteRenderer sprite;

    private DatosJuego datosJuego;

    public AudioClip saltoSfx;
    public AudioClip vidaSfx;
    public AudioClip recolectarSfx;
    private AudioSource audioSource;

    void Start()
    {
        tiempoInicio = (int)Time.time;
        tiempoNivel = 90;
        vulnerable = true;
        jugador = GameObject.FindGameObjectWithTag("Player").gameObject;
        player_idle = jugador.transform.Find("player-idle-1").gameObject;
        sprite = player_idle.GetComponent<SpriteRenderer>();
        hud = canvas.GetComponent<HUD_Control>();
        datosJuego = GameObject.Find("DatosJuego").GetComponent<DatosJuego>();

        hud.setPuntuacion(puntuacion);
        hud.setNumVidas(numVidas);
        hud.setTiempoEmpleado(tiempoEmpleado);

        audioSource = jugador.transform.Find
            ("AudioSource").gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("PowerUP").Length == 0)
        {
            GanarJuego();
        }

        //Actualizar tiempo empleado
        tiempoEmpleado = (int)(Time.time - tiempoInicio);
        hud.setTiempoEmpleado(tiempoEmpleado);
        //Comprobar si hemos consumido el tiempo del nivel
        if (tiempoNivel - tiempoEmpleado < 0) FinJuego();

        hud.setPuntuacion(puntuacion);
        hud.setNumVidas(numVidas);
    }

    public void FinJuego()
    {
        datosJuego.Ganado = false;
        SceneManager.LoadScene("FinNivel");
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
        hud.setPuntuacion(puntuacion);
    }

    public void QuitarVida()
    {
        if (vulnerable)
        {
            vulnerable = false;
            numVidas--;
            if (numVidas == 0) FinJuego();
            Invoke("HacerVulnerable", 1f);
            sprite.color = Color.red;
            audioSource.PlayOneShot(vidaSfx);
        }

    }

    public void GanarJuego()
    {
        puntuacion += (numVidas * 100) +
            (tiempoNivel - tiempoEmpleado);
        datosJuego.Puntuacion = puntuacion;
        datosJuego.Ganado = true;
        SceneManager.LoadScene("FinNivel");
    }

    public void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }
}
