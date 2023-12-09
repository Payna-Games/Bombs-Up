using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fireRate;
    [SerializeField] private TextMeshProUGUI fireRange;
    [SerializeField] private TextMeshProUGUI bombSpeed;
    [SerializeField] private BombLeftRight bombLeftRight;


    private void Start()
    {
        fireRate.text = MiniBompManager.miniBompManager.spawnSpeed.ToString();
        bombSpeed.text = MiniBompManager.miniBompManager.speed.ToString();
        fireRange.text = MiniBompManager.miniBompManager.range.ToString();
    }

    public void FireRateIncrease()
    {
        MiniBompManager.miniBompManager.spawnSpeed += 0.1f;
        fireRate.text = MiniBompManager.miniBompManager.spawnSpeed.ToString();
    }
    public void FireRateDecrease()
    {
        MiniBompManager.miniBompManager.spawnSpeed -= 0.1f;
        fireRate.text = MiniBompManager.miniBompManager.spawnSpeed.ToString();
    }
    public void BombSpeedIncrease()
    {
        bombLeftRight.bombSpeed += 20;
        bombSpeed.text = bombLeftRight.bombSpeed.ToString();
    }
    public void BombSpeedDecrease()
    {
        bombLeftRight.bombSpeed -= 20;
        bombSpeed.text = bombLeftRight.bombSpeed.ToString();
    }
    public void FireRangeIncrease()
    {
        MiniBompManager.miniBompManager.range += 30;
        fireRange.text = MiniBompManager.miniBompManager.range.ToString();
    }
    public void FireRangeDecrease()
    {
        MiniBompManager.miniBompManager.range -= 30;
        fireRange.text = MiniBompManager.miniBompManager.range.ToString();
    }
}
