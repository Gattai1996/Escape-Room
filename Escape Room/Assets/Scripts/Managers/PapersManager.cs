

public class PapersManager : HUDObjectsManager
{
    public static PapersManager Singleton { get; private set; }

    private void Start()
    {
        Singleton = this;
        SetupList();
    }
}
