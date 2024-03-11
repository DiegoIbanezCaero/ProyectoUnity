using UnityEngine;

public class ZeroController : MonoBehaviour
{
    private Animator animador;
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;
    private bool enSuelo = false;
    private bool puedeAtacar = true;
    public bool animar = false;

    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 80f;
    public Transform detectorSuelo;
    public LayerMask capaSuelo;

    [SerializeField] private Transform ControladorGolpe;
    [SerializeField] private float radioGolpe;


    void Start()
    {
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, rb.velocity.y);

        if (Mathf.Abs(movimientoHorizontal) > 0)
        {
            animador.SetBool("Caminando", true);
        }
        else
        {
            animador.SetBool("Caminando", false);
            animador.SetTrigger("Idle"); 
        }

       
        if (movimientoHorizontal < 0f && mirandoDerecha)
        {
            Voltear();
        }
        else if (movimientoHorizontal > 0f && !mirandoDerecha)
        {
            Voltear();
        }

        
        if (Input.GetKeyDown(KeyCode.Z) && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            animador.SetTrigger("Saltar");
            enSuelo = false;
        }

       
        if (Input.GetKeyDown(KeyCode.X) && puedeAtacar)
        {
            animador.SetTrigger("Atacar");
            puedeAtacar = false;
        }

        
        if (Input.GetKeyUp(KeyCode.X))
        {
            puedeAtacar = true;
        }

    }

    void FixedUpdate()
    {
        
        enSuelo = Physics2D.OverlapCircle(detectorSuelo.position, 0.2f, capaSuelo);

      
        if (enSuelo && rb.velocity.y == 0)
        {
            animador.ResetTrigger("Saltar");
        }
    }

 
    void Voltear()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

  
    void FinalizarSalto()
    {
        animador.ResetTrigger("Saltar");
        animador.SetTrigger("Idle");
    }


    void FinalizarAtaque()
    {
        animador.ResetTrigger("Atacar");
        animador.SetTrigger("Idle");
    }
    void ZeroFin()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Fin"))
            {
                animador.SetTrigger("ZeroFin");
            }
        }
    }
}
