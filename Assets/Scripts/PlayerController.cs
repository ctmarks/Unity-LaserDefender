using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float padding = 1.0f;

    private float xmin = 0.0f, xmax = 0.0f, ymin = 0.0f, ymax = 0.0f;

    void Start() {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, distance));

        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove() {
        //Keyboard Input

        //Vertical Movement
        if (Input.GetKey(KeyCode.W)) {
            //this.transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            //the line below does the same thing as the line above
            this.transform.position += Vector3.up * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)) {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
        }


        //Horizontal Movement
        if (Input.GetKey(KeyCode.A)) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D)) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //clamping player movement to the screen area
        float newX = Mathf.Clamp(this.transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(this.transform.position.y, ymin, ymax);

        this.transform.position = new Vector3(newX, newY, 0.0f);
    }
}
