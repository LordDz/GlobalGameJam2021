using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenBlit : MonoBehaviour
{
    
    //public Shader fullscreenBlitShader = null;
    public Material m_renderMaterial;
    
    
    void Start()
    {
        //if (fullscreenBlitShader == null)
        //{
        //    Debug.LogError("no fullscreen shader.");
        //    m_renderMaterial = null;
        //    return;
        //}
        
        if (m_renderMaterial == null)
        {
            Debug.LogError("no material.");
            return;
        }

        //m_renderMaterial = new Material(fullscreenBlitShader);
        
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_renderMaterial);
    }
}

