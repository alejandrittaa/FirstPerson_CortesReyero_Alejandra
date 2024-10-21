using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{

    [SerializeField] private float velocidadMovimiento;
    CharacterController characterController;
    
    
    void Start()
    {
        //obtenemos una vez el componente character controller, y lo almacenamos en una variable de tipo character controller
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        MoverYRotar();
    }

    void MoverYRotar()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector3 (h, v).normalized;

        //creamos esto para que los ojos del jugador cuadren con el movimiento del mismo, ya que si gira la cabeza, tendra que moverse hacia delante y dem�s, en base a la rotaci�n de su cabeza
        //giramos sobre la Y, que es el palo que atraviesa al jugador por en medio
        float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        //para que mi cuerpo quede orientado hacia donde me muevo
        transform.eulerAngles = new Vector3(0, anguloRotacion, 0);


        //si la magnitud/tama�o del vector es mayor de 0, si es positiva. 
        if (input.magnitude > 0)
        {

            //mi movimiento queda rotado en base del �ngulo calculado (un cuaternion indica una rotacion, mientras que un vector indica una posici�n)
            //tu frontal pasa a ser el �ngulo que tenga la c�mara
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward; 

            //como no va por f�sicas, tendremos que multiplicarlo por Time.deltaTime
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }
       
    }
}