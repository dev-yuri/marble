using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer _background;
    private SpriteRenderer _icon;
    private TextMeshPro _text;

    private void Awake()
    {
        _background = transform.Find("Background").GetComponent<SpriteRenderer>();
        _icon = transform.Find("Icon").GetComponent<SpriteRenderer>();
        _text = transform.Find("Text").GetComponent<TextMeshPro>();    
    }

    private void Start()
    {
        Setup("texto maior");
    }

    private void Setup(string text)
    {
        _text.text = text;
        _text.ForceMeshUpdate();
        Vector2 textSize = _text.GetRenderedValues(false);

        Vector2 padding = new Vector2(.7f,.2f);

        _background.size = textSize + padding;
        _background.transform.localPosition = new Vector3(_background.size.x/2f - .2f, 0);
    }
}
