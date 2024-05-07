using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public int maximum;
    public int current = 0;
    public Image mask;
    GameMaster GM;

    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maximum = GM.maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        current = GM.score;
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
