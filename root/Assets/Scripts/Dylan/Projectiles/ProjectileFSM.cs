using UnityEngine;
using System.Collections;

public class ProjectileFSM : MonoBehaviour
{
    public int damgaeOutput;
    public GameObject enemy;
    public float throwPower = 25.1f;
    private float mySpeed = 10.1f;
    private float maxDistance = 5.1f;
    private float myDist;
    public int bDamage = 10;
    public GameObject[] BB; // shots inside of a shot
    public int numOfShots = 10;
    


    public bool isFired = false; //a bool to check if the bullet is beign fired
    public bool doDmg = false;

    public enum projectileType
    {
        turretBullet,
        shotgunShell,
        gernade,
    }

    private projectileType pt;

    public void OnTriggerStay(Collider C)
    {
        if (C.GetComponent<Stats>())
        {

            if (C.GetComponent<Stats>().isEnemy)
            {
                C.GetComponent<Stats>().m_Health -= damgaeOutput;
                Destroy(gameObject);


            }
        }
    }


    void Update()
    {
        switch (pt)
        {
            case (projectileType.turretBullet):
             if (isFired == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * mySpeed);
                myDist += Time.deltaTime * mySpeed; //moves the bullet across the screen when the turret fire

                if (myDist > maxDistance)
                {
                    Destroy(gameObject);
                    //checks to see if the bullet has passed the maximum distance it can travel
                    //and if it dis destroy the object
                }
                   
            } break;

            case projectileType.gernade:
            if (isFired == true)
            {
            Vector3 forward = transform.TransformDirection(Vector3.forward * throwPower);
            transform.Translate(forward * Time.deltaTime * mySpeed);
            myDist += Time.deltaTime * mySpeed;

            //moves the bullet across the screen when the turret fire

                if (myDist > maxDistance)
                {
                    Destroy(gameObject);
                    //checks to see if the bullet has passed the maximum distance it can travel
                    //and if it dis destroy the object
                }
            }
                break;
          
        }
    }
}
