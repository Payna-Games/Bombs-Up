using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

public class EnoughMoney : TextPrint, IButtonPrice
{
    public int enough;

    public bool CanInteract = true;
    public bool adsClick = true;

    public Sprite adsImage;
    public Sprite oldImage;

    Button button;

    public int startPrice;
    public float increasePrice = 5;
    public int clickCount;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            clickCount = PlayerPrefs.GetInt(transform.name);
        }
        GetComponent<Animator>().enabled = false;
        NewPrice();
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(DecreaseMoney);
        //button.onClick.AddListener(SlotAddButton.slotAddButton.ObjectLocalize);
        button.onClick.AddListener(() => SlotAddButton.slotAddButton.ObjectLocalize());
        button.onClick.AddListener(NewPrice);
    }

    // Update is called once per frame
    void Update()
    {
        if (MoneyManager.moneyManager.totalMoney >= enough && CanInteract)
        {
            transform.GetComponent<Button>().interactable = true;
        }
        else if (MoneyManager.moneyManager.totalMoney < enough && adsClick)
        {        adsClick = false;
            GetComponent<Animator>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            GetComponent<Image>().sprite = adsImage;
            GetComponent<Button>().onClick.RemoveListener(NewPrice);
            GetComponent<Button>().onClick.RemoveListener(DecreaseMoney);
            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(AdsFalse);
            StartCoroutine(RotateContinuously());
        }
        //else
        //{
        //    transform.GetChild(1).gameObject.SetActive(false);
        //    GetComponent<Image>().sprite = oldImage;
        //    transform.GetComponent<Button>().interactable = false;
        //}
    }

    private void NewPrice()
    {
        enough = CalculatePrice(startPrice, increasePrice, clickCount);
        ButtonPrint(enough);
        //Vibrator.Vibrate();
        //Vibrator.Vibrate(200);
        clickCount += 1;
    }

    private void DecreaseMoney()
    {
        MoneyManager.moneyManager.DecreaseTotalMoney(enough);
    }

    public int CalculatePrice(int startPrice, float increasePrice, int clickCount)
    {
        if (gameObject.name == "Add Button" && clickCount > 4)
        {
            increasePrice = 140;    //eski deðer 70 => 12.12.23
            return (int)(increasePrice * clickCount);
        }
        if (gameObject.name == "Income" && clickCount > 1)
        {
            increasePrice = 800;    //eski deðer 400 => 12.12.23
            return (int)(increasePrice * clickCount);
        }
        return startPrice + (int)(increasePrice * clickCount);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(transform.name, clickCount - 1);
    }
    private void AdsFalse()
    {

        YsoCorp.GameUtils.YCManager.instance.adsManager.ShowRewarded
((bool ok) =>
{
    if (ok)
    {
        if (transform.name == "Add Button")
        {
            SlotAddButton.slotAddButton.ObjectLocalize();
        }
        else if (transform.name == "Income")
        {
            clickCount += 1;
        }

        Debug.Log("Button Ads");
    }
});
    }
    IEnumerator RotateContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            transform.DORotate(new Vector3(0, 0, 10), 0.2f);

            yield return new WaitForSeconds(0.1f);

            transform.DORotate(Vector3.zero, 0.2f);

            
        }

    }
}
