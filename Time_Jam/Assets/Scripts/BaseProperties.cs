using UnityEngine;
using System.Collections;

public class BaseProperties : MonoBehaviour
{
    #region Variables
    //Public
    [Header("EntityMovementProperties")]
    public float entitySpeed = 0.0f;    //How fast the entity can go
    public float originalSpeed = 0.0f;  //Original movement speed;

    [Header("EntityPathfindingProperties")]
    public Transform target;            //What to move towards/path find towards

    //Private
    #endregion

    #region UnityFunctions
    void Start ()
    {
	
	}

	void Update ()
    {
	
	}
    #endregion
}
