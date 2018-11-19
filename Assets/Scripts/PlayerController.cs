using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

	// Use this for initialization
    private Rigidbody rb;
    private float nextFire;
    private AudioSource audiosource;
    public float speed;
    public float tilt;
    public float fireRate;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;


	void Start () {
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x* -tilt);

    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audiosource.Play();
        }
    }
}
