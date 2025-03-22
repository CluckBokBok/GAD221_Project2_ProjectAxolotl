using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatController : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(h, v) * speed, ForceMode2D.Force);
    }
}
