using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float turnSpeed = 60f;
    private Animator animator;

    private void Start()
    {
        // Obtener el componente Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Inicializar moveDirection en 0 (quieto) si no hay teclas presionadas
        float moveDirection = 0f;

        // Movimiento hacia adelante (W) o hacia atrás (S)
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = 3f;  // Avanzar
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -3f;  // Retroceder
        }

        // Actualizar la posición del personaje solo si se mueve
        if (moveDirection != 0)
        {
            transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);
        }

        // Inicializar turnDirection en 0 (sin rotación) si no hay teclas presionadas
        float turnDirection = 0f;

        // Rotación izquierda (A) o derecha (D)
        if (Input.GetKey(KeyCode.A))
        {
            turnDirection = -3f;  // Girar a la izquierda
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnDirection = 3f;  // Girar a la derecha
        }

        // Rotar el personaje si hay una dirección de giro
        if (turnDirection != 0)
        {
            transform.Rotate(Vector3.up * turnDirection * turnSpeed * Time.deltaTime);
        }

        // Actualizar los parámetros Speed y Turn en el Animator
        animator.SetFloat("Speed", moveDirection);
        animator.SetFloat("Turn", turnDirection);
    }
}
