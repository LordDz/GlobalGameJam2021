using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ggj
{
    public class VaryingFOV : MonoBehaviour
    {
    	//float m_FieldOfView;
    	Vector2 maxMin = new Vector2(0.0f,53.0f);
    	
        // Start is called before the first frame update
        void Start()
        {
        	//m_FieldOfView = Camera.main.fieldOfView;
        	maxMin = new Vector2(Camera.main.fieldOfView-5.0f,maxMin[1]);
        }

        // Update is called once per frame
        void Update()
        {
        	float motion=(Mathf.Sin(Time.time*0.5f)+1.0f)*0.5f;        	
        	float fov=Mathf.Lerp(maxMin[0],maxMin[1],motion);
        	//Debug.Log("fov: " + fov);
        	Camera.main.fieldOfView = fov;
        }
    }
}
