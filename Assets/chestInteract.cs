using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestInteract : MonoBehaviour
{
    private bool isLooted = false;

    [SerializeField] private Sprite closeChest, openChest;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer.sprite = closeChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLooted)
            return;

        isLooted = true;
        _spriteRenderer.sprite = openChest;
     
    }
}
