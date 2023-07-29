using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string nextLevelName; // Nama level berikutnya
    public float distanceThreshold = 2f; // Jarak minimal untuk memicu perpindahan ke level berikutnya

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Cek jarak antara pemain dan titik transform skrip
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Jika pemain mendekati ujung level, pindah ke level berikutnya
        if (distanceToPlayer <= distanceThreshold)
        {
            GoToNextLevel();
        }
    }

    // Fungsi untuk pindah ke level berikutnya
    private void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GoToNextLevel();
        }
    }
}