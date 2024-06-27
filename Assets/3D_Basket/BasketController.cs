using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    [SerializeField]
    private AudioClip appleSound;
    [SerializeField]
    private AudioClip bombSound;
    AudioSource audio;
    GameObject director;

    void Start()
    {
        this.audio = GetComponent<AudioSource>();
        this.director = GameObject.Find("GameDirector");
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Apple")
        {
            Debug.Log("사과 획득");
            this.director.GetComponent<GameDirector>().GetApple();
            this.audio.PlayOneShot(this.appleSound);
        }
        else
        {
            Debug.Log("폭탄 획득");
            this.director.GetComponent<GameDirector>().GetBomb();
            this.audio.PlayOneShot(this.bombSound);
        }
        Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }

        }
    }
}
