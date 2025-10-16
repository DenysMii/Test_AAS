using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Text coinCounter;

    private AudioSource audio;
    private ParticleSystem ps;
    private List<ParticleSystem.Particle> particlesEnter;

    private void Start()
    {
        if (!TryGetComponent<AudioSource>(out audio))
            audio = gameObject.AddComponent<AudioSource>();

        ps = GetComponent<ParticleSystem>();
        particlesEnter = new List<ParticleSystem.Particle>();
    }

    private void OnParticleTrigger()
    {
        audio.Play();
        int counter = int.Parse(coinCounter.text);
        coinCounter.text = (counter + 1).ToString();
    }
}
