using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public GameObject FinishRamp;

    public float counter;
    // Start is called before the first frame update
    [NaughtyAttributes.Button("Add")]
    public void AddNewObstacle()
    {
        GameObject obs = GameObject.Instantiate(ObstaclePrefab);
        obs.transform.SetParent(this.transform);
        obs.transform.localPosition = new Vector3(0, 0, counter * 1.5f);
        obs.transform.localRotation = Quaternion.identity;
        int r = Random.Range(1, 10);
        obs.transform.GetChild(0).gameObject.SetActive(false);
        obs.transform.GetChild(1).gameObject.SetActive(false);

        if (r % 2 == 0)
        {
            obs.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            obs.transform.GetChild(1).gameObject.SetActive(true);
        }

        FinishRamp.transform.localPosition = new Vector3(FinishRamp.transform.localPosition.x, FinishRamp.transform.localPosition.y,
            2.5f + (1.5f*counter));
        counter++;
    }

    void SpawnTaxi()
    {
        
    }
}
