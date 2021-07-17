

public class PuzzlesManager : HUDObjectsManager
{
    public static PuzzlesManager Singleton { get; private set; }

    private void Start()
    {
        Singleton = this;
        SetupList();
    }
}
