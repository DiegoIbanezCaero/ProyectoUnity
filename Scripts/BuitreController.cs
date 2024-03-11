using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuitreController : MonoBehaviour
{
    public float velocidadMovimiento = 2f;
    public float distanciaMaxima = 5f; 
    public Animator animador;

    private bool moviendoseHaciaDerecha = true;
    private float puntoInicial;
    private float puntoFinal;

    void Start()
    {
       
        puntoInicial = transform.position.x;
        puntoFinal = puntoInicial + distanciaMaxima;

       
    }

    void Update()
    {
        
        if (moviendoseHaciaDerecha)
        {
            transform.Translate(Vector2.right * velocidadMovimiento * Time.deltaTime);
            if (transform.position.x >= puntoFinal)
            {
                Voltear();
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidadMovimiento * Time.deltaTime);
            if (transform.position.x <= puntoInicial)
            {
                Voltear();
            }
        }

      
        if (moviendoseHaciaDerecha)
        {
            transform.localScale = new Vector3(-2, 2, 2); 
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2); 
        }

    
    }

    void Voltear()
    {
        moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
    }
}