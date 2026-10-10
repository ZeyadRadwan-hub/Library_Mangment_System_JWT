namespace LibraryMangmentSystemJWT.Repo.Generic.Contract
{
    public interface IGenericRepo<T> where T : class
    {
        void AddObject(T obj);
        void UpdateObject(T obj);
        void DeleteObject(int id);
    }
}
