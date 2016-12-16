using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControllRigidAndEnableTest : MonoBehaviour {

    [SerializeField]
    public List<GameObject> DisableObjects;

    [SerializeField]
    public List<GameObject> AddRigidBodyObjects;

    public GameObject floor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float fps = 1f / Time.deltaTime;
        Debug.LogFormat("{0}fps", fps);
        if (Input.GetKeyUp(KeyCode.Space) && TrumpManager.I.State == TrumpAnimationState.Distruction) {
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
