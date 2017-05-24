using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5.0f;
    public float padding = 1.0f;

    private bool movingLeft = true;
    private float xmin, xmax;

    // Use this for initialization
    void Start () {
        foreach( Transform child in this.transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos() {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height));
    }

	// Update is called once per frame
	void Update () {
        //Horizontal Movement
        if (movingLeft) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            ClampMovement();
            if (this.transform.position.x <= xmin) {
                movingLeft = false;
            }
        } else if(!movingLeft){
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            ClampMovement();
            if (this.transform.position.x >= xmax) {
                movingLeft = true;
            }
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
}
