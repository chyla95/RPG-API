namespace RPG.API.Management.Utilities.Wrappers
{
    public interface IHttpContextWrapper
    {
        T? GetFeature<T>();
    }
}
