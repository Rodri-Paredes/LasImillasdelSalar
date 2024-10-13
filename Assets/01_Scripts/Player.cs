using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Velocidad de movimiento
    public float speed = 5f;
    // Fuerza del salto
    public float jumpForce = 5f;
    // Verificar si está en el suelo
    private bool isGrounded;

    // Referencia al Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Detectar colisión con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si estamos colisionando con el suelo, usando el nombre o la capa del objeto.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detectar cuando salimos del suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica si dejamos de colisionar con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
