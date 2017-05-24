using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float padding = 1.0f;
    public GameObject laser;
    public float projectileSpeed;

    private float xmin, xmax;

    void Start() {
    }
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        PlayerFire();
	}

    void PlayerMove() {
        //Keyboard Input

        //Horizontal Movement
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            ClampMovement();
        } else if (Input.GetKey(KeyCode.D)) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            ClampMovement();
        }
        
    }

    void ClampMovement() {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, distance));

        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;

        float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
        

        this.transform.position = new Vector3(newX, this.transform.position.y, 0.0f);
    }

    void PlayerFire() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject beam = Instantiate(laser, this.transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D rigid = beam.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector3(0.0f, projectileSpeed, 0.0f);
        }
    }
}
