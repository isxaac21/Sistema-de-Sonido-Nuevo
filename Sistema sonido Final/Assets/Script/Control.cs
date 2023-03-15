using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    public float velocidad;
    private Rigidbody2D rigidBody;
    private bool mirandoDerecha = true; 
    private Animator animator;
    public float salto;
    private BoxCollider2D boxCollider;
    public LayerMask suelocap; 
    

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
   
    void Update()
    {
        ProcesarMovimiento(); 
        ProcesarSalto();
    }

    bool EstaSuelo()
    {
       
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, suelocap );
        return raycastHit.collider != null;
        
    }

    void ProcesarSalto()
    {
       
        if(Input.GetKeyDown(KeyCode.Space) && EstaSuelo())
        {
            rigidBody.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySFX("Salto");
        }

    }

    void ProcesarMovimiento()
    {
      
        float inputMovimiento = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);
        

        GestionarOrientacion(inputMovimiento);
        

        if (inputMovimiento != 0f) 
        {
            
            animator.SetBool("EstaCorriendo", true);
            
        }
        else
        {
            animator.SetBool("EstaCorriendo", false);
        }
        
    }

    void GestionarOrientacion(float inputMovimiento)
    {
       
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
            
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            
        }
    }
}
