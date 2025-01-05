using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atividade2 : MonoBehaviour
{
    //fazer movimento de player top down e um sistema de coleta
    [SerializeField] float speed;
    Rigidbody2D rb;
    public bool stopPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopPlayer)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
