using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj
{
    public class Rotator : MonoBehaviour
    {
    	private float speed = -5000;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        	float rot=speed*Time.deltaTime;
 		gameObject.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
