using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    [SerializeField] private float vida;

    private Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}