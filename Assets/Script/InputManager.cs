using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public GameObject NoticePrefab;
    public GameObject ManPrefab;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var ray = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                new CautiousMessage(hit.point).Dispatch(GameObject.FindWithTag("Guard").GetComponent<Guard>());
                Instantiate(NoticePrefab, hit.point, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = GameObject.FindWithTag("MainCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {

                Instantiate(ManPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
