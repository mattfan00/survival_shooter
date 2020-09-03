using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collisionInfo) {
        string collisionName = collisionInfo.gameObject.name;

        if (collisionName == "Obstacles") {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
