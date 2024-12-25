using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    private FirstPerson player;
    [SerializeField] float vidas;
    //para guardadar los arrays del rigidbody
    Rigidbody[] huesos;

    // Start is called before the first frame update
    void Start()
    {
        //cogemos el componenete nav mesh
        agent = GetComponent<NavMeshAgent>();

        //para buscar al player, ponemos el nombre del c�digo que le hemos asiganado, en este caso firts person
        player = GameObject.FindObjectOfType<FirstPerson>();

        //PARA CAMBIAR LOS HUESOS DEL ENEMIGO A KINEMATICOS/ESTABLES (luego cuando lo matemos, invertimos esto, y caer� como una mu�eca)
        
            //para cambiar los huesos del personaje todos a kinematic mientras te persigue. Esto devolver� un array de rigidbody.
            huesos = GetComponentsInChildren<Rigidbody>();

            //llamamos al m�todo de cambiar el estado de los huesos
            cambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        //para hacer que persiga al player
        agent.SetDestination(player.gameObject.transform.position);
    }
    private void cambiarEstadoHuesos(bool estadoEnemigo)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estadoEnemigo;
        } 
    }

    public void RecibirDanho(float enemigo)
    {
            
    }

}
