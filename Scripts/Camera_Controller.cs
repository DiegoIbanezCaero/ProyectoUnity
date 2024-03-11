using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform objetivo; // El objeto que la c�mara seguir�
    public Vector3 offset = new Vector3(0f, -2f, 2f); // La posici�n relativa de la c�mara al personaje
    void Update()
    {
        if (objetivo != null)
        {
            // Calcula la posici�n a la que la c�mara debe moverse
            Vector3 posicionDeseada = objetivo.position + offset;

            // Interpolaci�n suave de la posici�n actual de la c�mara hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 5f);
        }
    }
}
