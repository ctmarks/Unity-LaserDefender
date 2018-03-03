using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFlash : MonoBehaviour {

    public float duration = 1.0F;

    private SpriteRenderer spriteRend;
    private bool spriteEnabled = false;

    void Start() {

        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.enabled = spriteEnabled;
    }

    IEnumerator BlinkTimer() {
        yield return new WaitForSeconds(duration);

        spriteRend.enabled = !spriteEnabled;
    }

    void Update() {
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);

        if (Input.GetKeyDown(KeyCode.Space)) {
            spriteEnabled = !spriteEnabled;
            spriteRend.enabled = spriteEnabled;

            StartCoroutine(BlinkTimer());

            

        }

 
    }
}
