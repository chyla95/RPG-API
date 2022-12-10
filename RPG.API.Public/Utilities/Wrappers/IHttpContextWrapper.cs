namespace RPG.API.Public.Utilities.Wrappers
{
    public interface IHttpContextWrapper
    {
        T? GetFeature<T>();
    }
}
