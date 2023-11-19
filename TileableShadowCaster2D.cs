using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(SpriteRenderer))]
public class TileableShadowCaster : MonoBehaviour
{
    SpriteRenderer renderer;
    GameObject shadowHackObject;
    // Start is called before the first frame update
    void UpdateShadow()
    {
        shadowHackObject.transform.localScale = new Vector3(renderer.size.x, renderer.size.y, 1f);
        shadowHackObject.transform.localPosition = Vector3.zero;
        shadowHackObject.transform.rotation = transform.rotation;
    }
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        shadowHackObject = new GameObject("2D Tiled Shadow Correction");
        shadowHackObject.transform.parent = transform;
        shadowHackObject.AddComponent<ShadowCaster2D>();
        UpdateShadow();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.hasChanged)
        {
            UpdateShadow();
        }
    }
}
