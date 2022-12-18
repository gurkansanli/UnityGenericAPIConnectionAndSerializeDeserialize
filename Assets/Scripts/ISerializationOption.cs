public interface ISerializationOption
{
    string ContentType { get; }
    string Authorization { get; }
    ResponseBase<T> Deserialize<T>(string json);
}
