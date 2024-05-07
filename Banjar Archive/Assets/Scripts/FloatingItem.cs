using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatHeight = 1f; // Tinggi melayang
    public float floatSpeed = 1f; // Kecepatan melayang

    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Hitung pergerakan melayang dengan sinusoidal
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update posisi GameObject
        transform.position = new Vector2(transform.position.x, newY);
    }
}
