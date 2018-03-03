using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Material spriteMaterial;

    private void Start() {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spriteMaterial = spriteRenderer.material;
            spriteMaterial.
        }
    }
}
