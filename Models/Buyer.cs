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
        public override string GetFields()
        {
            return base.GetFields() + $@", ""{nameof(FirstName)}"", ""{nameof(LastName)}"", ""{nameof(Phone)}""";
        }
        public override string GetValuesName()
        {
            return base.GetValuesName() + $", @{nameof(FirstName)}, @{nameof(LastName)}, @{nameof(Phone)}";
        }
        public override string ToString()
        {
            return base.ToString() + $@", {nameof(FirstName)}:""{FirstName}"", {nameof(LastName)}:""{LastName}"", {nameof(Phone)}:""{Phone}""";
        }
    }
    
}