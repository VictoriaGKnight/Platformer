using System.Collections.Generic;
using UnityEngine;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    [SerializeField] private ObjectPool coinPool;
    [SerializeField] private List<Transform> coinSpawnPoints = new List<Transform>();

    private List<GameObject> activeCoins = new List<GameObject>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        activeCoins.Clear();

        foreach (Transform spawnPoint in coinSpawnPoints)
        {
            GameObject coin = coinPool.GetObject();
            coin.transform.position = spawnPoint.position;
            coin.transform.rotation = spawnPoint.rotation;
            activeCoins.Add(coin);
        }
    }

    public void CollectCoin(GameObject coin)
    {
        if (activeCoins.Contains(coin))
        {
            activeCoins.Remove(coin);
        }

        coinPool.ReturnObject(coin);
    }

    public void ResetCoins()
    {
        foreach (GameObject coin in activeCoins)
        {
            if (coin != null)
            {
                coinPool.ReturnObject(coin);
            }
        }

        SpawnAllCoins();
    }
}