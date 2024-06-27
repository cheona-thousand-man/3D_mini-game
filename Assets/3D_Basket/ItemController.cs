using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float dropSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -this.dropSpeed, 0);
        // transform.position += Vector3.down * dropSpeed * Time.deltaTime;
        if (transform.position.y < -0.1f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDropSpeed(float speed)
    {
        this.dropSpeed = speed;
    }
}
