using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    public GameObject enemigo;
    private Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida < 0)
        {
            muerte();
            Invoke("Destroy",1f);
        }
    }
    private void muerte()
    {
        animator.SetTrigger("Muerte");
    }

    private void Destroy()
    {
        Destroy(enemigo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
