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
            return $@"""{nameof(Email)}"", ""{nameof(Password)}"", ""{nameof(FirstName)}"", ""{nameof(LastName)}"", ""{nameof(Phone)}"", ""{nameof(CreateDate)}"", ""{nameof(ModifyDate)}""";
        }
        public override string GetValues()
        {
            return $"'{Email}', '{Password}', '{FirstName}', '{LastName}', '{Phone}', '{CreateDate}', '{ModifyDate}'";
        }
        public override string ToString()
        {
            return $@"Email:""{nameof(Email)}"", Password:""{nameof(Password)}"", FirstName:""{nameof(FirstName)}"", LastName:""{nameof(LastName)}"", 
                    Phone:""{nameof(Phone)}"", CreateDate:""{nameof(CreateDate)}"", ModifyDate:""{nameof(ModifyDate)}""";
        }
    }
    
}
