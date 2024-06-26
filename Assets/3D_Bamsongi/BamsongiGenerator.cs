using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject bamsongiPrefab;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDirection = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDirection * 2000);
        }
    }
}
