namespace Representational_State_Transfer.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(string username);
    }
}
