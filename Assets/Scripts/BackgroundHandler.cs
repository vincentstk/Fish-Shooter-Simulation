using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    private Camera MainCamera;
    private MeshRenderer render;
    float offset = 0;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        render = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        offset += 0.1f * Time.deltaTime;
        render.material.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
        if (offset >= 1)
        {
            offset = 0;
        }
    }
}
