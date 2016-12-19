using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MappingTest : MonoBehaviour {
    [SerializeField]
    public Texture2D source;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (source != null)
        {
            Graphics.Blit(source, dest);
        }
    }
}
