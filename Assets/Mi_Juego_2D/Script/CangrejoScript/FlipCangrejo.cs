using Unity.VisualScripting;
using UnityEngine;

public class FlipCangrejo : MonoBehaviour
{

    private SpriteRenderer sprite;
    private GameObject crab_idle;
    private GameObject enemigo;
    private Vector3 ultimaPosicion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemigo = transform.parent.gameObject;
        crab_idle = enemigo.transform.Find("crab-idle-1").gameObject;
        sprite = crab_idle.GetComponent<SpriteRenderer>();
        ultimaPosicion = crab_idle.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionActual = crab_idle.transform.position;
        float diferenciaX = posicionActual.x - ultimaPosicion.x;

        if (diferenciaX > 0.001f)
            sprite.flipX = true;
        else if (diferenciaX < -0.001f)
            sprite.flipX = false;

        ultimaPosicion = posicionActual;
    }
}
