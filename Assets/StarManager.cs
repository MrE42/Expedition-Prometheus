using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StarManager : MonoBehaviour
{

    public LevelControl level;

    private ParticleSystem p;
    public float scalar = 2;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        p = gameObject.GetComponent<ParticleSystem>();
        scale = p.emission.rateOverTimeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        var emission = p.emission;
        emission.rateOverTimeMultiplier = scale * (1 + ((level.currentWaveNumber+1) / scalar));
    }
}
