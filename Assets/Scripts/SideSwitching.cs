using UnityEngine;
using TMPro;
public class SideSwitching
{
    public static bool gameStart = false;
    private static bool hasSideSwitched = false;
    public static bool HasSideSwitched => hasSideSwitched;
    public static bool displaytimer = false;
    private static float timeLeftToDisplay = 0;
    private static bool switchBackground = false;
    private static float timeToDisplay = 3;
    [RuntimeInitializeOnLoadMethod]
    static void Start()
    {
        float repeatingInterval = 5f;
        TimerManager.StartTimer(repeatingInterval, SideSwitchingAttempt);
    }

    static void Update()
    {

        timeLeftToDisplay -= Time.deltaTime;
        if (timeLeftToDisplay <= 0)
        {
            Debug.Log("Switching sides over");
            displaytimer = false;
            SwitchSides();
        }


    }

    private static void SideSwitchingAttempt()
    {
        if (gameStart)
        {
            float rand = Random.Range(1, 10);
            bool shouldSwitchSides = rand > 5;

            if (shouldSwitchSides)
            {
                Debug.Log("Switching sides");
                switchBackground = true;
                displaytimer = true;
                timeLeftToDisplay = timeToDisplay;
                TimerManager.StartTimer(3f, SwitchSides, true);
            }
        }
    }

    private static void SwitchSides()
    {
        if(gameStart)
        {
            displaytimer = false;
            switchBackground = false;
            Color originalColor = Camera.main.backgroundColor;
            hasSideSwitched = !hasSideSwitched;
            Camera.main.backgroundColor = Color.green;
            TimerManager.StartTimer(.5f,
                () => Camera.main.backgroundColor = originalColor,
                true);
        }

    }

}