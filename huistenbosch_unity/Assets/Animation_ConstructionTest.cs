﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animation_ConstructionTest : MonoBehaviour {

   
	void Start () {
        removeRigidBody(transform);
	}
	

	void Update () {
      
	}
    
    void removeRigidBody(Transform parent) {
        for (int i = 0; i < parent.childCount; ++i)
        {
            if (parent.GetChild(i).gameObject.GetComponent<Trump>() != null)
            {
                Destroy(parent.GetChild(i).gameObject.GetComponent<Rigidbody>());
            }
            else {
                removeRigidBody(parent.GetChild(i));
            }
        
        }
    }
}
