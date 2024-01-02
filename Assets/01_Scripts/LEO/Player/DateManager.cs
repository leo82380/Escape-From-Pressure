using EasyJson;

public class DateManager : MonoSingleton<DateManager>
{
    public PlayerData playerData;

    public void Save()
    {
        EasyToJson.ToJson(playerData, "PlayerData", true);
    }
    
    public void Load()
    {
        playerData = EasyToJson.FromJson<PlayerData>("PlayerData");
    }
}
