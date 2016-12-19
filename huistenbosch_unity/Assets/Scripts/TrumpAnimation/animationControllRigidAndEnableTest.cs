using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControllRigidAndEnableTest : MonoBehaviour {

    [SerializeField]
    public List<GameObject> DisableObjects;

    [SerializeField]
    public List<GameObject> AddRigidBodyObjects;

    public GameObject floor;
    
	void Start () {
		
	}
	
	void Update () {
        float fps = 1f / Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space)) {
            foreach (GameObject go in AddRigidBodyObjects ){
                go.AddComponent<Rigidbody>();
                if (go.GetComponent<MeshCollider>() != null) {
                    go.GetComponent<MeshCollider>().convex = true;
                }
            }
            foreach (GameObject go in DisableObjects) {
                go.SetActive(false);
            }
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            floor.SetActive(false);
        }
	}
}
