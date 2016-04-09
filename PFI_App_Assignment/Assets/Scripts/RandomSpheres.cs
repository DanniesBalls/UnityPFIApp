using UnityEngine;
using System.Collections;

public class RandomSpheres : MonoBehaviour {

	[SerializeField]
	GameObject objToRandomize;

	public int objectsToSpawn = 0;
	int count;

	int minAreaSizeX = -5;
	int maxAreaSizeX = 15;
	int areaSizeY = 8;

    float radius;

	void Start()
	{
		StartCoroutine ("SpawnSpheres");
	}

	public IEnumerator SpawnSpheres ()
	{
		Bounds maxBounds = RecursiveMeshBB (objToRandomize);
		Debug.Log (maxBounds);
		radius = maxBounds.size.magnitude;
		Debug.Log (radius);

		SphereAudio asgAu = new SphereAudio();

		for (int i = 0; i < objectsToSpawn; i++) 
		{
			Vector3 randomPosition = new Vector3 (Random.Range (minAreaSizeX, maxAreaSizeX), Random.Range (-areaSizeY, areaSizeY), 10);

			if ( !Physics.CheckSphere (randomPosition, radius) )
			{
				if ( objToRandomize == gameObject )
				{
					GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = randomPosition;
				}
				else
				{
					//Instantiate (objToRandomize, randomPosition, Quaternion.identity);
					GameObject tmp = Instantiate (objToRandomize, randomPosition, Quaternion.identity) as GameObject;
					count++;
				
					asgAu.AttachSound("Drum", count, tmp);
					//Debug.Log(tmp.transform.position + " " + count);
				}
			}
			yield return new WaitForSeconds(0.09f);
		}
	}

	static private Bounds RecursiveMeshBB(GameObject go)
	{
		Debug.Log ("Bounds is Called");
		MeshFilter[] mfs = go.GetComponentsInChildren <MeshFilter>();
		Debug.Log (mfs.Length);
		if (mfs.Length > 0)
		{
			Bounds b = mfs[0].mesh.bounds;
			for (int i = 1; i < mfs.Length; i++)
			{
				b.Encapsulate(mfs[i].mesh.bounds);
			}
			return b;
		}
		else
			return new Bounds();
	}

}
