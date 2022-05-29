using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] ParticleSystem burst;
    [SerializeField] SpriteRenderer soul;
    [SerializeField] SpriteRenderer glow;
    [SerializeField] ParticleSystem twinkle;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(twinkle);
            soul.enabled = false;
            glow.enabled = false;
            burst.Play();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
