using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectScript : MonoBehaviour {
    public Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        //src is the full rendered scene that you would normally
        //send directly to the monitor. We are intercepting
        //this so we can do a bit more, work before passing it on.

        //pretending to do image effect in cpu

        // probably apply some kind of texture.SetPixels(pixels);

        Graphics.Blit(src, dest, mat);
    }
}
