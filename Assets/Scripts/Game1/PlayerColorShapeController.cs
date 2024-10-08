using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorShapeController : MonoBehaviour
{
    [SerializeField] private ColorShapeData playerData;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        ColorObject.OnChangeColor += UpdateColor;
        ShapeObject.OnChangeShape += UpdateShape;
    }

    private void OnDisable()
    {
        ColorObject.OnChangeColor -= UpdateColor;
        ShapeObject.OnChangeShape -= UpdateShape;
    }

    private void UpdateColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

    private void UpdateShape(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}