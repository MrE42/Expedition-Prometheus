using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class DissolvingController : MonoBehaviour
{
    public VisualEffect VFXGraph;
    public SkinnedMeshRenderer skinnedMesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    private bool running = false;
    private Material[] skinnedMaterials;

    // Start is called before the first frame update
    void Start()
    {
        if (skinnedMesh != null)
        {
            skinnedMaterials = skinnedMesh.materials;
            
        }
        if (VFXGraph != null)
        {
            VFXGraph.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            if (gameObject.GetComponent<crewmateAI>().die)
            {
                StartCoroutine(DissolveCo());
                running = true;
            }
        }
    }

    IEnumerator DissolveCo ()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }

        if(skinnedMaterials.Length >0)
        {
            float counter = 0;
            while(skinnedMaterials[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for(int i=0; i<skinnedMaterials.Length; i++)
                {
                    skinnedMaterials[i].SetFloat("_DissolveAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}