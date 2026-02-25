using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Simple List
    private List<GameObject> tearPool = new List<GameObject>();

    // Init Pool
    public void InitializeTearPool(GameObject tearType, Transform tearsSlot, int poolSize)
    {
        // Create All Tears
        for (int i = 0; i < poolSize; i++)
        {
            GameObject tear = Instantiate(tearType, transform.position, Quaternion.identity, tearsSlot);
            tear.SetActive(false); // Instant Disable Tears
            tearPool.Add(tear);
        }
        Debug.Log($"Pool Size {poolSize} tears");
    }

    public void UseCouroutine(GameObject tear, float tearLifetime)
    {
        StartCoroutine(DeactivateAfterTime(tear, tearLifetime));
    }

    public GameObject GetInactiveTear(GameObject tearType, Transform tearsSlot, bool canExpand, int maxPoolSize)
    {
        // Search a Disable Tear
        for (int i = 0; i < tearPool.Count; i++)
        {
            if (!tearPool[i].activeInHierarchy)
            {
                return tearPool[i];
            }
        }

        // If All Tears is active and we can expand the pool
        if (canExpand && tearPool.Count < maxPoolSize)
        {
            // Cr¨¦er une nouvelle tear
            GameObject newTear = Instantiate(tearType, transform.position, Quaternion.identity, tearsSlot);
            newTear.SetActive(false);
            tearPool.Add(newTear);
            return newTear;
        }

        return null;
    }

    // Couroutine for disable Tears
    private IEnumerator DeactivateAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }
}
