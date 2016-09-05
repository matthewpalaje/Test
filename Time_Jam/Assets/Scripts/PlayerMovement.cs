using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    //Public
    public Transform respawnZone;
    public float playerSpeed = 0.0f;
    public float rotSpeed = 0.0f;
    //Private
    private Rigidbody myRB;
    #endregion

    #region UnityFunctions
    void Start ()
    {
        myRB = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate ()
    {
        Move();
	}
    #endregion

    #region MovementFunctions
    private void Move()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float hAxis = Input.GetAxisRaw("Horizontal");           //Store the hAxis as a float
            float vAxis = Input.GetAxisRaw("Vertical");             //Store the vAxis as a float

            Vector3 movePos = new Vector3(hAxis, 0, vAxis);         //Where to move
            myRB.AddForce(movePos * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);    //Move the player
        }
    }
    #endregion 
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "DeathZone")
        {
            transform.position = respawnZone.position;
        }
    }
}
