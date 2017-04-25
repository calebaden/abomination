using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public List<GameObject> Collectibles = new List<GameObject>();

    public float minSpeed;
    public float maxSpeed;
    private float speed;

    public Transform target;

    public bool active;

    public ParticleSystem particlesystem;

    public float lifetime = 180;

    public bool isTurning = false;


    // Use this for initialization
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Collectibles.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        lifetime -= 1 * Time.deltaTime;
        if (transform.position.y < 20 || isTurning)
        {
            //Debug.Log("Turning");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 10 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
