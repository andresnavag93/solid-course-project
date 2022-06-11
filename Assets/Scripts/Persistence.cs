using UnityEngine;

public class Persistence
{
    private const string DurationKey = "duration";
    public float LoadLastDuration()
    {
        return PlayerPrefs.GetFloat(DurationKey, 0);
    }

    public void SaveLastDuration(float duration)
    {
        PlayerPrefs.SetFloat(DurationKey, duration);
        PlayerPrefs.Save();
    }
}
