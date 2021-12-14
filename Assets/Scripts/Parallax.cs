using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{

    public float speed = 0.02f;
    public RawImage floor;

    void Start()
    {

    }

    void Update()
    {
        float finalSpeed = speed * Time.deltaTime;
        floor.uvRect = new Rect(floor.uvRect.x + finalSpeed, 0f, 1f, 1f);
    }
}
