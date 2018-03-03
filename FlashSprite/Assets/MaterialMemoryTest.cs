using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialMemoryTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string materialName = this.GetComponent<SpriteRenderer>().material.ToString();
        print(materialName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
