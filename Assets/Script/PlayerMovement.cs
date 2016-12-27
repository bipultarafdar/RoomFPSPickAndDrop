using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;

    float x;
    float y;
    Vector3 movement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.GetComponent<MouseLook>().curryRot, 0);

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, 0f, y);
        movement = movement.normalized * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
