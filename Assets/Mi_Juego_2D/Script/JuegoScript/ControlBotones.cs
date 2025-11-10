using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBotonJugar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void OnBotonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }
}
