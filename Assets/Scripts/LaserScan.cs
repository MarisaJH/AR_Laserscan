using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScan : MonoBehaviour
{
	public GameObject linePrefab;
	// makes the lasers slightly lower than the green dot
	public float ydecrement;	
	// distance to draw lines when they don't hit a wall
	public float linedistance;
	
	private int numberLines;
	private float angle;
	private string laserskey = "Lasers";
	private string anglekey = "Angle";
	private int defaultLasers = 13;
	private float defaultAngle = 180.0f;
	private GameObject[] lines;
	
	void Start() {
		numberLines = PlayerPrefs.GetInt(laserskey, defaultLasers);
		angle = PlayerPrefs.GetFloat(anglekey, defaultAngle);
		
		lines = new GameObject[numberLines];
		for (int i =0; i < lines.Length; i++) {
			lines[i] = Instantiate(linePrefab);
		}
	}
	
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
		
		float currangle = angle/2;
        float angleincrement = angle / (numberLines-1);
		for (int i =0; i < lines.Length; i++) {
			var lineRenderer = lines[i].GetComponent<LineRenderer>();
			Vector3 direction = Quaternion.Euler(0,currangle,0) * transform.forward;
			Vector3 origin = new Vector3(transform.position.x, transform.position.y - ydecrement, transform.position.z); 
			
			RaycastHit hit;
			// Does the ray intersect any objects excluding the player layer
			if (Physics.Raycast(origin, direction, out hit, Mathf.Infinity, layerMask))
			{
				Vector3[] positions = new Vector3[]{origin, hit.point};
				lineRenderer.SetPositions(positions);
				//Debug.Log(hit.distance);
				
				//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
				//Debug.Log("Did Hit");
			}
			else
			{
				Vector3[] positions = new Vector3[]{origin, direction*linedistance};
				lineRenderer.SetPositions(positions);
				
				//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
				//Debug.Log("Did not Hit");
			}
			
			currangle -= angleincrement;
		}
    }
}
