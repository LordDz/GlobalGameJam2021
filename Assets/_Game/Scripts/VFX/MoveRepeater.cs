using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj
{
    public class MoveRepeater : MonoBehaviour
    {
    	public float timeCutoff = 1.0f;
    	private float speed = 100.0f;
    	private float superHaxTimer = 0.0f;
    	private Vector3 initialPos;
        // Start is called before the first frame update
        void Start()
        {
        	initialPos = gameObject.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
        	if(superHaxTimer > timeCutoff)
        	{
        		superHaxTimer = 0.0f;
        		gameObject.transform.position = initialPos;
        	}
        	else
        	{
        		superHaxTimer+=Time.deltaTime;
        	}
        	Vector3 pos = gameObject.transform.position + new Vector3(speed * Time.deltaTime,0,0);
 		gameObject.transform.position = pos;
        }
    }
}
