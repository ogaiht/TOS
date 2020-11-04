namespace TOS.Common.Serialization.Json
{
    public interface IJsonSerializer
    {
        string Serialize(object obj);

        T Deserialize<T>(string json);
    }
}
