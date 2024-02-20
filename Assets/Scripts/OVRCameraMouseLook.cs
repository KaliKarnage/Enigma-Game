using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlesToCenter : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;

    public float strength = 10f; // Adjust this to control the speed at which particles move towards the center

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        int maxParticles = particleSystem.main.maxParticles;
        if (particles == null || particles.Length < maxParticles)
        {
            particles = new ParticleSystem.Particle[maxParticles];
        }

        int particleCount = particleSystem.GetParticles(particles);

        Vector3 centerPoint = transform.position; // Assuming the center is the position of the GameObject this script is attached to

        for (int i = 0; i < particleCount; i++)
        {
            Vector3 directionToCenter = centerPoint - particles[i].position;
            Vector3 velocityTowardsCenter = directionToCenter.normalized * strength;
            particles[i].velocity = velocityTowardsCenter;
        }

        particleSystem.SetParticles(particles, particleCount);
    }
}
