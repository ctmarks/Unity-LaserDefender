using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTexSwap : MonoBehaviour {

    Texture2D mColorSwapTex;
    Color[] mSpriteColors;
    SpriteRenderer mSpriteRenderer;


    public enum SwapIndex {
        Outline = 25,
        SkinPrim = 254,
        SkinSec = 239,
        HandPrim = 235,
        HandSec = 204,
        ShirtPrim = 62,
        ShirtSec = 70,
        ShoePrim = 253,
        ShoeSec = 248,
        Pants = 72
    }

    void Start() {
        mSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            SwapColor(SwapIndex.SkinPrim, new Color(0f, 0f, 0f, 1f));
        }
    }

    public void InitColorSwapTex() {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; i++) {
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
        }

        colorSwapTex.Apply();

        mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    
    public void SwapColor(SwapIndex index, Color color) {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    
}
