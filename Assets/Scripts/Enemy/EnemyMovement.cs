using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [Tooltip("Objetivo que estara siguiendo")]
    public Transform target;
    [Range(0,5)]
    [Tooltip("Velocidad de desplazamiento")]
    public float speed;
    [Range(0,2)]
    [Tooltip("Velocidad de rotacion")]
    public float rotationSpeed;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Mantiene la altura a la que se encuentra el jugador y la posicion x del enemigo
        Vector2 corner = new Vector2(transform.position.x, target.position.y);
        //Una vez tenemos formado el triángulo calculamos el Cateto Opuesto y el Cateto Adyacente
        float catetoAdyacente = corner.y - transform.position.y;
        float catetoOpuesto = corner.x - target.position.x;
        /*
            Bien ahora para encontrar el ángulo tenemos que despejarlo de la tangente de la sig forma:
            Tan θ = cO/cA
            -ArcTan Tan θ- = ArcTan(cO/cA)
            θ = ArcTan(cO/cA)

            Bien ahora que tenemos una fórmula para calcular el ángulo lo implementamos en el código:
        */
        float angle = Mathf.Atan2(catetoOpuesto, catetoAdyacente) * Mathf.Rad2Deg;

        body.rotation -= angle / speed; //TODO buscar la manera en la que se vaya sumando, el sprite se comporta raro a causa de esto
        body.velocity = (target.position - transform.position).normalized * speed;
    }
}
