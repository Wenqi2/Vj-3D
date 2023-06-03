using UnityEngine;

public class ActivateTrap : MonoBehaviour
    
{
    public ParticleSystem particle;
    public bool collided = false;
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Stop();
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collided = true;
            particle.Play();
        }
    }
}