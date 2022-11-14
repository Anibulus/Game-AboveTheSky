using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    [Tooltip("Desplazamiento del seeker")]
    public float speed = .7f;
    public Vector3 startPosition;
    private Rigidbody2D body;
    void Awake()
    {
        this.startPosition = this.transform.position;
        this.body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = Mathf.Clamp(speed, 0f, .5f); 
        body.velocity = transform.up * speed;
    }
}
