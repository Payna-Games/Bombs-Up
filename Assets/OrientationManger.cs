using UnityEngine;
using YG; // Yandex SDK'yı içeri aktardığınızdan emin olun.

public class OrientationManager : MonoBehaviour
{
    void Awake()
    {
        // Bu GameObject sahne değişikliğinde yok edilmesin
        DontDestroyOnLoad(gameObject);

        // Yandex SDK'yı başlat
        

        // Cihazın türünü kontrol et ve ekran yönünü ayarla
        CheckDeviceAndSetOrientation();
      
    }

    private void CheckDeviceAndSetOrientation()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Debug.Log("Mobil cihaz tespit edildi. Ekran yönü Portrait olarak ayarlandı.");
        }
       
    }
}