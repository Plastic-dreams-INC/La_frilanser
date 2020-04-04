using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D physics; //Física afecta al jugador
    private Vector3 change; //Cambio de direccion
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        physics = GetComponent<Rigidbody2D>(); //Obtiene el componente de tipo Rigidbody2D  
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero; //Posicion estatica
        //Detecta si se ha presionado alguna tecla de movimiento relacionada
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimation();
    }
    void UpdateAnimation()
    {
        //Si se ha iniciado algun movimiento llama a la funcion que se encargara de cambiar la posicion del sprite y anima el sprite.
        if (change != Vector3.zero)
        {
            Movement();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true); //El arbol A referencia al arbol Walk,inicia la animacion del sprite en el arbol.
        }
        else
        {
            animator.SetBool("moving", false); //El arbol walk Referencia al arbol A, personaje estático.
        }
    }
    void Movement()
    {
        physics.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
