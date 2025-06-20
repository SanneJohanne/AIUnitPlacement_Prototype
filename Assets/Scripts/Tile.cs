using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject basilToSpawn;
    public GameObject cheeseToSpawn;
    public GameObject mushroomToSpawn;
    public GameObject coinPrefab;

    public int basilCost = 10;
    public int mushroomCost = 20;
    public int cheeseCost = 30;

    private CoinManager coinManager;

    private void Start()
    {
       coinManager = CoinManager.instance;
    }
    public void MushroomOnTileDrop(Itemdragdrop mushroom)
    {
        if (coinManager.coins >= mushroomCost)
        {
            coinManager.SpendCoins(mushroomCost);
            Instantiate(mushroomToSpawn, transform.position, transform.rotation);
        }
        else
        {
            mushroom.transform.position = mushroom.startDragPosition;
        }
    }

       public void CheeseOnTileDrop(Itemdragdrop cheese)
    {
        if (coinManager.coins >= cheeseCost)
        {
            coinManager.SpendCoins(cheeseCost);
            Instantiate(cheeseToSpawn, transform.position, transform.rotation);
        }
        else
        {
            cheese.transform.position = cheese.startDragPosition;
        }
    }

       public void BasilOnTileDrop(Itemdragdrop basil)
    {
        if (coinManager.coins >= basilCost)
        {
            coinManager.SpendCoins(basilCost);
            GameObject basilObject = Instantiate(basilToSpawn, transform.position, transform.rotation);
            StartCoroutine(GenerateCoinsOverTime(basilObject));
        }
        else
        {
            basil.transform.position = basil.startDragPosition;
        }
    }

    private IEnumerator GenerateCoinsOverTime(GameObject basilToSpawn)
    {
        while (basilToSpawn != null)
        {
            yield return new WaitForSeconds(Random.Range(10f,15f));

            if (basilToSpawn != null)
            {
                Vector3 spawnPosition = basilToSpawn.transform.position + new Vector3(0, 0.5f, 0);
                Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
            }
            
        }

    }
}
