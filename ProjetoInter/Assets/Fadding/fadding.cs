using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadding : MonoBehaviour
{
    public Texture fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    private void OnGUI()    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);

    }

    public float BeginFade(int direction)
    {
        
        fadeDir = direction;
        Invoke("ResetEffect", 2);
        return (fadeSpeed);
        
    }

    public void ResetEffect() {
        drawDepth = -1000;
        //alpha = 1.0f;
        //fadeDir = -1;
}


}
