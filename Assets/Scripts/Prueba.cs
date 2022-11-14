using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    /*
    Valores:
    [Range(0,5)] Delimita el rango de los valores de una variable
    [Min(0)] Establece el valor mínimo asignable desde el editor
    [Max(5)] Establece el valor máximo asignable desde el editor
    Visibilidad:

    [Serializefield] muestra una variable en el editor
    [HideInInspector] oculta una variable en el editor
    Editor:

    [Header(“título”)] coloca un título
    [Space] añade un espacio
    [Tooltip] añade una descripción que se muestra al colocar el mouse por encima de la propiedad
    [TextArea] añade una caja de texto más grande
    Funciones:

    [ContextMenu(“nombre”)] nos permite ejecutar una función desde el inspector a través del nombre dado

    [ContextMenu(“nombre”)] nos permite ejecutar una función d
        // Start is called before the first frame update
    */
    void Start()
    {
        int i = 0;
        Debug.Log("mensajes");
        Debug.LogWarning("mandar warning");
        Debug.LogError("mandar error");
        //te muestra el valor de i en cosola en color azul
        Debug.LogFormat($"<color=blue>{i}</color>");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Permite mostrar todo los campos del tipo
    [System.Serializable]
    public class PruebaClase
    {
        public int entero { get; set; }
    }
}
