using System.Collections.Generic;

namespace NVoucher.Model
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool Term { get; set; }
        public bool IsVerified { get; set; }
        public long Numbers { get; set; }
       
    }
}