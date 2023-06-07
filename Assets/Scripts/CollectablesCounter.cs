using System;
using TMPro;
using UnityEngine;

public class CollectablesCounter : MonoBehaviour
{
    [SerializeField] private MazeZombie zombie;

    private void Start()
    {
        zombie.OnCollect += Zombie_OnCollect;
        Zombie_OnCollect(zombie, new());
    }

    private void Zombie_OnCollect(object sender, EventArgs e)
    {
        GetComponent<TextMeshProUGUI>().text = $"{zombie.CollectablesCollected}/{zombie.NeedToCollect}";
    }
}
