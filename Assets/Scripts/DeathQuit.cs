using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathQuit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}
