using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
	{
	public float speed=1;
	void FixedUpdate ()
		{
		transform.Rotate( Vector3.forward * speed * Time.deltaTime );
		}
	}
