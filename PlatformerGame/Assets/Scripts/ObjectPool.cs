using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> pool = new List<GameObject>();

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Reactivating pooled object: " + obj.name);
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab, transform);
        newObj.name = prefab.name + "_Pooled_" + pool.Count;

        Debug.Log("Instantiating new pooled object: " + newObj.name);

        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        Debug.Log("Returning object to pool: " + obj.name);
        obj.SetActive(false);
    }
}