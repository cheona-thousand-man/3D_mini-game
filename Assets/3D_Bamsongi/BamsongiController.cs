using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
            this.transform.SetParent(other.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Shoot(new Vector3(0, 65, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
