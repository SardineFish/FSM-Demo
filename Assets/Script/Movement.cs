using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float Speed = 500;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.fixedDeltaTime);
    }
}
