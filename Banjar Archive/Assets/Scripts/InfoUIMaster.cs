using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoUIMaster : MonoBehaviour
{
    [SerializeField] GameObject gambarJudul;
    [SerializeField] TMP_Text judul;
    [SerializeField] GameObject uiLLM;

    [SerializeField] Sprite defaultImg;
    [TextArea]
    [SerializeField] string defaultPrompt;

    public void SetUiArtifak(Sprite img, string text)
    {
        gambarJudul.GetComponent<Image>().sprite = img;
        judul.text = text;
    }

    public void SetUiArtifak()
    {

    }

    public void exitUi()
    {
        uiLLM.SetActive(false);
    }
}
