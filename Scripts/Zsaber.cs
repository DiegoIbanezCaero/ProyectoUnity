using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zsaber : MonoBehaviour
{
    [SerializeField] private Transform ControladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float daño;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.X))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TomarDaño(daño);
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorGolpe.position,radioGolpe);
    }
}
