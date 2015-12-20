using UnityEngine;
using System.Collections;

public class ShiftAndJump : MonoBehaviour
	{
	public Transform ShiftObject;
	public float speed;
	public float jumpStep;
	void FixedUpdate ()
		{
		Vector3 pos = ShiftObject.localPosition ;
		pos.x+=speed*Time.deltaTime;
		if( pos.x>jumpStep )	pos.x-=jumpStep;
		if( pos.x<-jumpStep )	pos.x+=jumpStep;
		ShiftObject.localPosition=pos;
		}
	}
