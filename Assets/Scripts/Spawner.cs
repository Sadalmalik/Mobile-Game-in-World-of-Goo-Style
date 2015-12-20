using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
	{
	public List<GameObject>Objects;
	[Space(10)]
	public GameObject[]Prefabs;
	void Start ()
		{
		Objects=new List<GameObject>();
		}

	
	[Space(10)]
	public float SpawnDelay=0.4f;
	float nextTime;
	public int spawnCount=0;
	public Transform SpawnPoint;
	public Text	PointsDisplay;
	[Space(10)]
	public int points=0;
	void Update ()
		{
		float time=Time.time;
		if( time>=nextTime && spawnCount>0 )
			{
			nextTime=time+SpawnDelay;
			spawnCount--;

			GameObject OBJ = Instantiate( Prefabs[ Random.Range( 0 , Prefabs.Length ) ] );
			OBJ.GetComponent<ObjectController>().spawner=this;
			OBJ.transform.position = SpawnPoint.position ;
			OBJ.transform.rotation = Quaternion.Euler( 0 , 0 , Random.Range( 0 , 360 ) );
			Rigidbody2D RIG = OBJ.GetComponent<Rigidbody2D>();
			if( null!=RIG ) RIG.velocity=new Vector3( Random.Range(-5,5) , Random.Range(-10,-15) , 0 );
			Objects.Add( OBJ );
			}
		if( Objects.Count<8 && spawnCount==0 )
			{
			spawnCount=Random.Range(12,26);
			nextTime=Time.time+SpawnDelay;
			}
		if( null!=PointsDisplay )
			{
			PointsDisplay.text=points.ToString();
			}
		}
	}
