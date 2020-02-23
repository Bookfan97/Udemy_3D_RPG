using RPG.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    BaseStats baseStats;

    private void Awake()
    {
        baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
    }

    private void Update()
    {
        GetComponent<Text>().text = String.Format("{0:0}", baseStats.GetLevel());
    }
}
