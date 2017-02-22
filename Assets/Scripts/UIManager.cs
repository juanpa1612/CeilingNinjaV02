using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int points;
    public Text pointsText;

    private void Update()
    {
        pointsText.text = (""+ points);
    }

}
