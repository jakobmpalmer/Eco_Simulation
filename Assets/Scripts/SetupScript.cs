using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class SetupScript : MonoBehaviour
{

	//Random random = new Random();
	//UnityEngine.Random random = new UnityEngine.Random();

//World Spawn
	protected int WORLD_SIZE = 100;
	public float amp = 5f;
	public float freq = 10f;

	public GameObject dirtBlock;
	public GameObject grassBlock;
	public GameObject airBlock;
	private GameObject current_ground;

	public GameObject barrier;

//Fauna Spawn
	public GameObject rabbitPrefab;

	public GameObject turnipPrefab;

	private GameObject[] theMap;

	private Vector3 myPos;

    // Start is called before the first frame update
    void Start()
    {
		theMap = new GameObject[WORLD_SIZE * WORLD_SIZE];
		InstantiateMap(WORLD_SIZE);
		CreateBarrier();
		SpawnFauna(10);
		//SpawnFlora();
	}

	public void InstantiateMap(int WorldSize)
	{
			
			int count = 0;
			
			myPos = this.transform.position;

			for (int i = 0; i < WorldSize; i++) {			
				for (int j = 0; j < WorldSize; j++) {

					float rNum = (Random.value * 100);
					Debug.Log(rNum);

					if(rNum <= 40 )
					{
						current_ground = dirtBlock;
					// } else if (rNum < 80 && rNum > 40 ){
					} else if (rNum < 100 && rNum > 40 ){
						current_ground = grassBlock;
					} else {	
						current_ground = airBlock;
					}
					Vector3 y = new Vector3(myPos.x + i, Mathf.PerlinNoise( myPos.x + i/freq, myPos.z + j/freq) * amp, myPos.z + j);
					theMap[count] = Instantiate(current_ground, y, Quaternion.identity);
					
					count++;

				} // FOR (j)	
			} // FOR (i)

			Debug.Log(count);
	}

	public void SpawnFauna(int count)
	{
		for(int i = 0; i < count; i++){
			// float rNumX = (Random.value * WORLD_SIZE);
			// float rNumZ = (Random.value * WORLD_SIZE);

			int rNum = (int)(Random.value * WORLD_SIZE);

			// Vector3 randomLoc = new Vector3(rNumX, 20, rNumZ);
			Vector3 randomLoc = new Vector3(theMap[rNum].transform.position.x, theMap[rNum].transform.position.y + 1, theMap[rNum].transform.position.z);
			// Instantiate(rabbitPrefab, randomLoc, Quaternion.identity);
			Instantiate(rabbitPrefab, randomLoc, Quaternion.identity);
		}
	}

	public void SpawnFlora()
	{
		float rNum;
		// for each block
		int count = 0;
		for(int i = 0; i < WORLD_SIZE-1; i++){
			for(int j = 0; j < WORLD_SIZE; j++){
				Debug.Log("count:: " + count);
				Debug.Log("BLOCK: " + theMap[count]);
				rNum = (Random.value);
			// if it is a grass block
			if((theMap[count].name == "GrassBlock(Clone)") && (rNum > 0.40f)){
				// then spawn 3-6 plants on block (in random locations)
				//Debug.Log("Plant here!! @ i: " + i + " | j: " + j + " || COUNT:: " + count);
				if((rNum * 100) % 3 == 1)
				{
					//Instantiate(turnipPrefab, new Vector3(theMap[count].transform.position.x + rNum, 0.61f, theMap[count].transform.position.z), Quaternion.identity);
					//Instantiate(turnipPrefab, new Vector3(theMap[count].transform.position.x, 0.61f, theMap[count].transform.position.z), Quaternion.identity);
				}
				//Instantiate(turnipPrefab, new Vector3(theMap[count].transform.position.x - rNum, 0.61f, theMap[count].transform.position.z), Quaternion.identity);
				Instantiate(turnipPrefab, new Vector3(theMap[count].transform.position.x, 0.61f, theMap[count].transform.position.z), Quaternion.identity);
				}
				count++;
			}
		}
	}

	public void CreateBarrier()
	{
		int WorldBound = WORLD_SIZE++;

		Instantiate(barrier, new Vector3(-1, 0, -1), Quaternion.identity);

		for(int i = 0; i < WORLD_SIZE; i++)
		{
			Instantiate(barrier, new Vector3(i, 0, -1), Quaternion.identity);
			Instantiate(barrier, new Vector3(-1, 0, i), Quaternion.identity);
			Instantiate(barrier, new Vector3(WorldBound, 0, i), Quaternion.identity);
			Instantiate(barrier, new Vector3(i, 0, WorldBound), Quaternion.identity);
		}
	} // create barrier




} // CLASS
