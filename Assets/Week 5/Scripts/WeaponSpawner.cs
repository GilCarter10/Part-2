using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public void FireArrow(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
