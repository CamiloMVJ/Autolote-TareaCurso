namespace AutoloteAPI.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        bool IsUser(string username, string password); 
    }
}
