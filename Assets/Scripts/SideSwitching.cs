using UnityEngine;

public class SideSwitching
{
    private static bool hasSideSwitched = false;
    public static bool HasSideSwitched => hasSideSwitched;

    [RuntimeInitializeOnLoadMethod]
    static void Start()
    {
        float repeatingInterval = 5f;
        TimerManager.StartTimer(repeatingInterval, SideSwitchingAttempt);
    }

    private static void SideSwitchingAttempt()
    {
        float rand = Random.Range(1, 10);
        bool shouldSwitchSides = rand > 5;

        if (shouldSwitchSides)
        {
            Color originalColor = Camera.main.backgroundColor;
            hasSideSwitched = !hasSideSwitched;
            Camera.main.backgroundColor = Color.green;
            TimerManager.StartTimer(.5f,
                                    ()=>Camera.main.backgroundColor = originalColor,
                                    true);
        }
    }


}