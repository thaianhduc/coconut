using System;

namespace Coconut.Web.Models
{
    public class UglyFactModel
    {
        public int SpentWeeks { get; set; }
        public int CloseToCreatorWeeks { get; set; }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class EditUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
