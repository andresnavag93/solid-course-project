using System.IO;

public class FilePersistence : ILoad, ISave
{
    private const string Path = "Assets/Resources/savedFile.txt";

    public float LoadLastDuration()
    {
        var reader = new StreamReader(Path);
        var durationString = (reader.ReadToEnd());
        reader.Close();

        if (!string.IsNullOrEmpty(durationString))
        {
            return float.Parse(durationString);
        }
        return 0;
    }

    public void SaveLastDuration(float duration)
    {
        var writer = new StreamWriter(Path, true);
        writer.WriteLine(duration);
        writer.Close();
    }
}
