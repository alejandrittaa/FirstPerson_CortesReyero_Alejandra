using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    //creamos una variable camara
    private Camera cam;
    void Start()
    {
        //referenciamos a la camara principal de nuestro juego
        cam = Camera.main;
    }

    void Update()
    {
        //el 0 es el click izquierdo, el 1 el click derecho y el 2 la rueda del ratón.
        //SI HACEMOS CLICK DERECHO
        if(Input.GetMouseButtonDown(0))
        {
            //los datos de entrada que necesitamos son:
            //origen - dirección - out RaycastHit (dato de salida secundario, devuelve informacion del impacto) -  distancia
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                //el hitinfo solo tiene información del impacto
                //esta sentencia solo sirve para mostrar el nombre de en lo que ha impactado
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
