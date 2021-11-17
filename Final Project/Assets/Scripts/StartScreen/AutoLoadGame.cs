using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadGame : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
