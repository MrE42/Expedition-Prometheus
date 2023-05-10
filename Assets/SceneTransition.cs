using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneTransition : MonoBehaviour
{

    public void LoadMainLevel(string scene)
    {
        SceneManager.LoadScene(scene); // Replace "MainLevel" with the name of your main level scene.
    }
}
