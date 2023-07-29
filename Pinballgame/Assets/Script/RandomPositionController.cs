using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionController : MonoBehaviour
{
    public GameObject coin;
    public int coincount =0;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(2, 2, 2);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(coincount < 3)
        {
            StartCoroutine(RandomSpawner());
            coincount++;
        }
        else
        {
            return;
        }
    }

    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(1f);
        Vector3 randomPos = new Vector3(Random.Range(-5, 5), 2, Random.Range(-5, 5));
        Instantiate(coin, randomPos,Quaternion.identity);
    }
}
