using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk menggunakan SceneManager

public class chestInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite openSprite, closeSprite;

    private bool isOpen;
    private float autoCloseDelay = 3f; // Waktu delay sebelum chest tertutup

    private Coroutine autoCloseCoroutine;
    public GameObject quiz;
    public bool UIactive;
    public bool inRange;

    private void Update()
    {
        // Cek apakah tombol "E" ditekan
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact(); // Panggil method Interact() ketika "E" ditekan

            if (UIactive)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Interact()
    {
        if (isOpen)
        {
            StopInteract();
        }
        else
        {
            isOpen = true;
            spriteRenderer.sprite = openSprite;

            // Reset atau mulai countdown jika chest terbuka
            if (autoCloseCoroutine != null)
                StopCoroutine(autoCloseCoroutine);
            autoCloseCoroutine = StartCoroutine(AutoCloseChest());
        }
    }

    public void StopInteract()
    {
        isOpen = false;
        spriteRenderer.sprite = closeSprite;

        // Hentikan countdown jika chest tertutup
        if (autoCloseCoroutine != null)
            StopCoroutine(autoCloseCoroutine);
    }


    public void Resume()
    {
        quiz.SetActive(false);
        Time.timeScale = 1f;
        quiz.SetActive(false); 
        UIactive = false;
    }

    void Pause()
    {
        quiz.SetActive(true);
        Time.timeScale = 1f;
        quiz.SetActive(true);
        UIactive = true;
    }

    private void Start()
    {
        quiz.SetActive(false);
    }

    private IEnumerator AutoCloseChest()
    {
        // Tunggu selama beberapa detik sebelum menutup chest
        yield return new WaitForSeconds(autoCloseDelay);

        // Tutup chest secara otomatis jika tidak ada interaksi selama beberapa detik
        StopInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

}
