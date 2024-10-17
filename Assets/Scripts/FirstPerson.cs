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
        Vector3 movimiento = new Vector3 (h, 0 ,v).normalized;

        //creamos esto para que los ojos del jugador cuadren con el movimiento del mismo, ya que si gira la cabeza, tendra que moverse hacia delante y demás, en base a la rotación de su cabeza
        //giramos sobre la Y, que es el palo que atraviesa al jugador por en medio
        float anguloRotacion = Mathf.Atan2(movimiento.x, movimiento.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

        if(movimiento.magnitude > 0)
        {
            //para que mi cuerpo quede orientado hacia donde me muevo
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            //como no va por físicas, tendremos que multiplicarlo por Time.deltaTime
            characterController.Move(movimiento * velocidadMovimiento * Time.deltaTime);

        }
       
    }
}
