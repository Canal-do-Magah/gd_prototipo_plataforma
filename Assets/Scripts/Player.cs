using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 5f;

    private Rigidbody2D rb;
    public bool estouChao = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moverX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moverX, 0f, 0f) * velocidade * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && estouChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            estouChao = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            estouChao = true;
        }
    }
}
