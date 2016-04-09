using UnityEngine;
using System.Collections;

public class RandomSpheres : MonoBehaviour {

	[SerializeField]
	GameObject objToRandomize;

	GameObject[] spheres;
	public GameObject[] Spheres
	{
		get{return spheres;}
	}

	public int objectsToSpawn = 0;
	int count;

	public int minAreaSizeX = -5;
	public int maxAreaSizeX = 15;
	public int minAreaSizeY = -8;
	public int maxAreaSizeY = 6;

    float radius;

	public IEnumerator SpawnSpheres (string musicKit)
	{
		SphereAudio asgAu = new SphereAudio();
		spheres = new GameObject[objectsToSpawn];

		Bounds maxBounds = RecursiveMeshBB (objToRandomize);
		radius = maxBounds.size.magnitude;

		for (int i = 0; i < objectsToSpawn; i++) 
		{
			Vector3 randomPosition = new Vector3 (Random.Range (minAreaSizeX, maxAreaSizeX), Random.Range (minAreaSizeY, maxAreaSizeY), 10);

			if ( !Physics.CheckSphere (randomPosition, radius) )
			{
				if ( objToRandomize == gameObject )
				{
					GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = randomPosition;
				}
				else
				{
					GameObject tmp = Instantiate (objToRandomize, randomPosition, Quaternion.identity) as GameObject;
					count++;
				
					asgAu.AttachSound(musicKit, count, tmp);
					spheres[count] = tmp;
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
