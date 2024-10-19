namespace DuPontRegistry.Models
{
    public class Buyer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Buyer()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }
        public static string GetFields()
        {
            return UserFields + $@", ""{nameof(FirstName)}"", ""{nameof(LastName)}"", ""{nameof(Phone)}""";
        }
        public static string GetValuesName()
        {
            return UserValuesName + $", @{nameof(FirstName)}, @{nameof(LastName)}, @{nameof(Phone)}";
        }
        public override string ToString()
        {
            return UserToString + $@", {nameof(FirstName)}:""{FirstName}"", {nameof(LastName)}:""{LastName}"", {nameof(Phone)}:""{Phone}""";
        }
    }
}