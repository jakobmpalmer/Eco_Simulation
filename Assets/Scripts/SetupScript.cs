using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class SetupScript : MonoBehaviour
{

	//Random random = new Random();
	//UnityEngine.Random random = new UnityEngine.Random();

	protected int WORLD_SIZE = 20;

	public GameObject dirtBlock;
	public GameObject grassBlock;
	public GameObject airBlock;
	private GameObject current_ground;

    // Start is called before the first frame update
    void Start()
    {
		InstantiateMap(WORLD_SIZE);

	}

	public void InstantiateMap(int WorldSize)
	{
			
			int count = 0;

			for (int i = 0; i < WorldSize; i++) {			
				for (int j = 0; j < WorldSize; j++) {

					float rNum = (Random.value * 100);
					Debug.Log(rNum);

					if(rNum <= 40 )
					{
						current_ground = dirtBlock;
					} else if (rNum < 80 && rNum > 40 ){
						current_ground = grassBlock;
					} else {	
						current_ground = airBlock;
					}

					Instantiate(current_ground, new Vector3(i, 0, j), Quaternion.identity);
					count++;

				} // FOR (j)	
			} // FOR (i)

			Debug.Log(count);
	}

	public void SpawnBunnies(int count)
	{


	}




} // CLASS
