using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : BaseProperties
{
    #region Variables
    //Public

    //Private
    private NavMeshAgent myAgent;   //Get a reference to the navmesh component
    #endregion

    #region UnityFunctions
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();     //Get the navmeshagent component
        entitySpeed = myAgent.speed;
        originalSpeed = entitySpeed;                //Store the original speed
        //InvokeRepeating("Move", 0.0f, 0.4f);        //How often the player moves towards the target
    }

    void LateUpdate()
    {
        Move();
    }
    #endregion

    #region MovementFunction
    private void Move()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();    //Get the player
        myAgent.speed = entitySpeed;                                                      //Control the navmesh speed
        myAgent.SetDestination(target.position);                                          //Move towards the target
    }
    #endregion

    #region TimeFunction
    //Called upon entering/being in the slow field
    public void SlowTime()
    {
        entitySpeed /= 3;   //Divide the movement speed by 2
    }

    //Called after exiting the slow field
    public void NormalTime()
    {
        entitySpeed = originalSpeed;    //Reset the speed 
    }
    #endregion
}
