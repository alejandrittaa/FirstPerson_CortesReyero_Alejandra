using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizado;
    CharacterController characterController;


    private float velocidadRotacion;


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

        Vector2 input = new Vector3(h, v).normalized;


        //si la magnitud/tamaño del vector es mayor de 0, si es positiva. 
        if (input.magnitude > 0)
        {
            //creamos esto para que los ojos del jugador cuadren con el movimiento del mismo, ya que si gira la cabeza, tendra que moverse hacia delante y demás, en base a la rotación de su cabeza
            //giramos sobre la Y, que es el palo que atraviesa al jugador por en medio
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            //suavizar el movimiento del personaje
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, suavizado);

            //para que mi cuerpo quede orientado hacia donde me muevo
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            //mi movimiento queda rotado en base del ángulo calculado (un cuaternion indica una rotacion, mientras que un vector indica una posición)
            //tu frontal pasa a ser el ángulo que tenga la cámara
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            //como no va por físicas, tendremos que multiplicarlo por Time.deltaTime
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }

    }
}
