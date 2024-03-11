using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform objetivo; // El objeto que la cámara seguirá
    public Vector3 offset = new Vector3(0f, -2f, 2f); // La posición relativa de la cámara al personaje
    void Update()
    {
        if (objetivo != null)
        {
            // Calcula la posición a la que la cámara debe moverse
            Vector3 posicionDeseada = objetivo.position + offset;

            // Interpolación suave de la posición actual de la cámara hacia la posición deseada
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 5f);
        }
    }
}
