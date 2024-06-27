using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject applePrefab;
    [SerializeField]
    private GameObject bombPrefab;
    [SerializeField]
    private int dropItemMaxNumber = 1;
    [SerializeField]
    private float initialDropSpeed = 0.01f;
    private float dropSpeed;
    private int bombRate = 10;
    float span = 1.0f;
    float delta = 0;

    void Start()
    {
        dropSpeed = initialDropSpeed;
    }

    public void SetDropSpeed(float speed)
    {
        dropSpeed = speed;
    }

    public void SetBombRate(int rate)
    {
        bombRate = rate;
    }

    public void SetGenerateInterval(float time)
    {
        delta = time;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            for (int i = 0; i < Random.Range(1, dropItemMaxNumber); i++)
            {
                this.delta = 0;
                GameObject item;

                if (Random.Range(1, 101) > bombRate)
                {
                    item = Instantiate(applePrefab);
                }
                else
                {
                    item = Instantiate(bombPrefab);
                }

                float x = Random.Range(-1, 2);
                float z = Random.Range(-1, 2);
                item.transform.position = new Vector3(x, Random.Range(4, 8), z);

                ItemController itemController = item.GetComponent<ItemController>();
                if (itemController != null)
                {
                    itemController.SetDropSpeed(dropSpeed);
                }
            }
        }
    }
}
