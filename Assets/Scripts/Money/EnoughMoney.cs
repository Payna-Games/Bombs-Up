using UnityEngine;
using UnityEngine.UI;

public class EnoughMoney : TextPrint, IButtonPrice
{
    private int enough;

    public bool CanInteract = true;

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

        NewPrice();
        button = transform.GetComponent<Button>();
        button.onClick.AddListener(DecreaseMoney);
        button.onClick.AddListener(NewPrice);
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Button>().interactable = MoneyManager.moneyManager.totalMoney >= enough && CanInteract;

        //if (MoneyManager.moneyManager.totalMoney >= enough && CanInteract)
        //{
        //    transform.GetComponent<Button>().interactable = true;
        //}
        //else
        //{
        //    transform.GetComponent<Button>().interactable = true;
        //}
    }

    private void NewPrice()
    {
        enough = CalculatePrice(startPrice, increasePrice, clickCount);
        string moneyPrint = enough.ToString();
        ButtonPrint(enough);
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
            increasePrice = 70;
            return enough + (int)increasePrice;
        }
        if (gameObject.name == "Income" && clickCount > 1)
        {
            increasePrice = 200;
            return enough + (int)increasePrice;
        }
        return startPrice + (int)(increasePrice * clickCount);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt(transform.name, clickCount - 1);
    }
}
