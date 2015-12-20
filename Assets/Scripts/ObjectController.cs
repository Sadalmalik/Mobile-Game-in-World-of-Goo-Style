using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour
	{
	public Spawner spawner;
	public int type=0;
	void Start ()
		{
		
		}
	public GameObject[]cantactList=new GameObject[32];
	public ObjectController[]cantact=new ObjectController[32];

	public int pointer=0;
	void FixedUpdate ()
		{
		if( destroyed )
			Destroy(this.gameObject);
		pointer=0;
		}

//	void OnCollisionStay2D(Collision2D col)	{}
	void OnTriggerStay2D(Collider2D col)
		{
		ObjectController con = col.gameObject.GetComponent<ObjectController>();
		if( con!=null )
			{
			cantactList[pointer]=con.gameObject;
			cantact[pointer++]=con;
			}
		}
	bool destroyed=false;
	void ObjectDestroy( int points )
		{
		if( destroyed ) return;
		destroyed=true;
		spawner.points+=points;
		points+=2;
		for( int i=0 ; i<pointer ; i++ )
			if( cantact[i].type==this.type )
				cantact[i].ObjectDestroy( points );
		spawner.Objects.Remove( this.gameObject );
		}
	void OnMouseDown()
		{
		ObjectDestroy( -1 );
		}   
	}
