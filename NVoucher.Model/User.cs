namespace NVoucher.Model
{
    public class User
    {
         string UserName { get; set; }
         decimal Balance { get; set; }
    }
    public interface IUser
    {
         string UserName { get; set; }
         decimal Balance { get; set; }
    }
}
