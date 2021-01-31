using System.Collections;
using RPGM.Core;
using UnityEngine;

namespace ggj
{
    /// <summary>
    /// Marks a sprite that should fade away when the player character enters it's trigger.
    /// </summary>
    /// <typeparam name="FadingSprite"></typeparam>
    [RequireComponent(typeof(Collider2D))]
    public class FadingSpriteChildren : InstanceTracker<FadingSpriteChildren>
    {
        internal SpriteRenderer spriteRenderer;

        internal float alpha = 1, velocity, targetAlpha = 1;
        
        internal int srcLayer;
        public int targetLayer;

        void Awake()
        {
            spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
            srcLayer = spriteRenderer.sortingOrder;
            Debug.Log(spriteRenderer);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            targetAlpha = 0.25f;
            spriteRenderer.sortingOrder=targetLayer;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            targetAlpha = 1f;
   	    spriteRenderer.sortingOrder=srcLayer;

        }
        
        void Update()
        {
        	float speed = 0.1f;
        	float max = 1.0f;
        	alpha=Mathf.Lerp(alpha,targetAlpha,Time.time*speed*Time.deltaTime);
	        //spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * speed, max));	        
	        spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
        	//float currAlpha=alpha;
        	//alpha=
		//spriteRenderer.alpha=targetAlpha;
        }
    }
}
