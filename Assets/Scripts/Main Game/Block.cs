using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitPoints = 1;
    public int scoreValue = 100;
    public GameObject destroyEffect; // optional particle effect prefab

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                if (destroyEffect)
                    Instantiate(destroyEffect, transform.position, Quaternion.identity);

                Destroy(gameObject);
                // Optionally: notify a score system here
            }
        }
    }
}

