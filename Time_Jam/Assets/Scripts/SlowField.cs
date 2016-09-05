using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlowField : MonoBehaviour
{
    #region Variables
    //Public
    public float collisionRadius = 0.0f;    //How big the collision zone will be 
    public float maxRadius = 10.0f;         //Max size of the collision zone
    public List<GameObject> objects;
    //Private
 
    #endregion

    #region UnityFunctions
    void Start()
    {
        Destroy(gameObject, 3.0f);
        Invoke("ReturnSpeed", 2.9f);
    }

    void Update()
    {
        ExpandRadius();
    }
    #endregion

    #region FieldFunctions
    private void ExpandRadius()
    {
        Debug.Log(transform.localScale.magnitude);
        if (transform.localScale.magnitude <= maxRadius)
        {
            transform.localScale += new Vector3(collisionRadius, collisionRadius, collisionRadius);   //Increase the radius
        }
    }
    #endregion 

    #region CollisionFunctions
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            objects.Add(other.gameObject);
            other.gameObject.GetComponent<EnemyMovement>().SlowTime();    //Slow the entity down
        }
    }
    private void ReturnSpeed()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            objects[i].gameObject.GetComponent<EnemyMovement>().NormalTime();   //Return there speed
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponent<EnemyMovement>().NormalTime();  //Return entity 
        }
    }
    #endregion
}
