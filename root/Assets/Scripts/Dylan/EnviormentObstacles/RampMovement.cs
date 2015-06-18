using UnityEngine;
using System.Collections;

public class RampMovement : MonoBehaviour
{
    private float speed = 2f;
    private float currentHeight;
    private float range = 5;

    public bool isActive = true;
    public float Timer;

    public float rotate;
    public float delay;

    public GameObject obstacle;

	// Use this for initialization
	void Start () 
    {
        delay = Random.Range(5, 15);
        obstacle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        Timer += Time.deltaTime;

        if (Timer > delay && isActive == true)
        {
            obstacle.SetActive(false);
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            currentHeight -= Time.deltaTime * speed;
            print("Going Up");

            if (currentHeight <= 0)
            {
                isActive = false;
                Timer = 0;
            }
        }

        if (Timer > delay && isActive == false)
        {
            obstacle.SetActive(true);
            transform.Translate((Vector3.up * Time.deltaTime * speed) * -1);
            currentHeight += Time.deltaTime * speed;
            print("Going Down");

            if (currentHeight >= range)
            {
                isActive = true;
                Timer = 0;
            }
        }
	}
}
