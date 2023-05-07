using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    public Vector3 offset;
    Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.rotation *= Quaternion.Euler(offset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * -1 * Time.deltaTime * speed);
        Destroy(this.gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats.health -= 5f;
    }


}
