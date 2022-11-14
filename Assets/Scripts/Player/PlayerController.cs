using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body; 

    [SerializeField]
    private float movementX;
    [SerializeField]
    private float movementY;

    public float speed;
    public float maxSpeed;
    public int rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {   /*Siempre habra un movimiento vertical, pero detecta si hay o no rotacion y lo aplica cada frame*/
        body.rotation -= movementX * rotationSpeed;

        speed = Mathf.Clamp(speed+movementY, 1.5f, maxSpeed);
        //Darle velocidad lineal. Esto se define al frente del avion
        body.velocity = transform.up * speed;
    }

    void OnFire(InputValue fireValue)
    {
        SoudManager.sharedInstance.PlayShoot();
        Rigidbody2D bulletBody = ObjectPooler.sharedInstance.GetPoolObject(Layers.BULLET).GetComponent<Rigidbody2D>();

        bulletBody.transform.position = this.transform.position;
        bulletBody.rotation = this.body.rotation;

        Debug.Log(this.transform.position);
        Debug.Log(bulletBody.transform.position);

        bulletBody.gameObject.SetActive(true);
    }

    //Es asi porque se define desde el new input
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
