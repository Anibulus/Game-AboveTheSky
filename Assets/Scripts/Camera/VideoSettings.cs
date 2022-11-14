using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSettings : MonoBehaviour
{
    [Tooltip("Tasa de frames por segundo")]
    public int frameRate = 60;

    [Space]
    [Header("Configuracion de movimiento de la camara")]
    public Vector3 startPostion;
    public Vector3 velocity = Vector3.zero; //Posicion de la camara
    public float dampingTime = 0.3f; //Tiempo de amortiguacion de la camara
    public Vector3 offset = new Vector3(0.0f, 0.0f, -10f); //Posicion de la camara
    
    [Tooltip("Objetivo que va a seguir")]
    public Transform target;
    
    void Awake()
    {
        Application.targetFrameRate = frameRate;
        startPostion = this.transform.position;
    }

    void Update()
    {
        MoveCamera(true);
    }

    void MoveCamera(bool smooth)
    {
        Vector3 destination = new Vector3(
            target.position.x - offset.x,
            target.position.y - offset.y,
            offset.z
        );

        if (smooth)
            this.transform.position = Vector3.SmoothDamp(
                current : this.transform.position,
                target : destination,
                currentVelocity : ref velocity, //Paso por referencia
                smoothTime : dampingTime
            );
        else
            this.transform.position = destination;
        
    }
}
