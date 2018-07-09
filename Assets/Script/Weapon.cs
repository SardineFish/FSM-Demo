using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject ShootPos;
    public GameObject BulletPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeFire(Vector3 target)
    {
        var dir = target - ShootPos.transform.position;
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.rotation *= Quaternion.FromToRotation(bullet.transform.forward, dir);
        bullet.transform.position = ShootPos.transform.position;
    }
}
