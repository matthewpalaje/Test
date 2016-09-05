using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour
{
    #region Variables
    //Public
    public float shootDelay = 0.0f;     //Delay between shots
    public float bulletSpeed = 0.0f;    //How fast the bullet travels
    public float rayDistance = 0.0f;    //Distance of the raycast
    public GameObject abilityPrefab;    //Stores abilities, convert to an array later
    public GameObject bulletPrefab;     //Stores bullet types, convert to an array later
    public Transform bulletSpawnPos;    //Stores the bullets spawn transform
    //Private
    private bool canShoot = true;       //Determins if the player can shoot or not
    #endregion

    #region UnityFunctions
    void Start ()
    {
	
	}

	void Update ()
    {
        PlaceAbility();
        ShootInput();
	}
    #endregion

    #region Abilities
    private void PlaceAbility()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if(Physics.Raycast(ray.origin, ray.direction, out hit, rayDistance))
        {
            if(hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0))
            {
                Instantiate(abilityPrefab, hit.point, transform.rotation);
            }
        }
    }
    #endregion

    #region ShootFunctions
    private void ShootInput()
    {
        if(Input.GetMouseButton(1) && canShoot == true)
        {
            Invoke("Shoot", 0.3f);  //Shoot after the shootDelay
            canShoot = false;
        }
    }

    private void Shoot()
    {
        GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity) as GameObject;
        bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);                //Give the clone force to travel
        canShoot = true;    //Enable shooting
    }
    #endregion
}
