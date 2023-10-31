using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    
    private TextMeshProUGUI _text;
    private int _counter;


    // Start is called before the first frame update
    void Start()
    {
        PowerUp.OnPowerUpPicked += updateStarsCollected;

        _text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        _counter = 0;
    }

    private void OnDestroy()
    {
        PowerUp.OnPowerUpPicked -= updateStarsCollected;
    }

    private void OnDisable()
    {
       PowerUp.OnPowerUpPicked -= updateStarsCollected;
    }

    private void updateStarsCollected()
    {
        _counter++;
        _text.text = "Stars " + _counter + "/3";
    }
}
