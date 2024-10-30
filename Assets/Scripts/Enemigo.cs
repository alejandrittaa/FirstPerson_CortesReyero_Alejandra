using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    private FirstPerson player;

    // Start is called before the first frame update
    void Start()
    {
        //cogemos el componenete nav mesh
        agent = GetComponent<NavMeshAgent>();

        //para buscar al player, ponemos el nombre del código que le hemos asiganado, en este caso firts person
        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        //para hacer que persiga al player
        agent.SetDestination(player.gameObject.transform.position);
    }
}
