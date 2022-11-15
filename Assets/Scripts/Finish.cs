using UnityEngine;

public class Finish : MonoBehaviour
{
    public ParticleSystem Fireworks_1;
    public ParticleSystem Fireworks_2;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Fireworks_1.Play();
            Fireworks_2.Play();
        }
    }
}
