using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteEnemigo : MonoBehaviour
{
    [SerializeField] private Enemigo mainScript;
    /*public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        if (vidas <= 0)
        {
            //cuando escribimos game object en miniscula para que se destruya asi mismo. el this. no es necesario pero nos deja mas claro que es a si mismo.
            //Destroy(this.gameObject);
            cambiarEstadoHuesos(false);
        }
        
    }*/
}
