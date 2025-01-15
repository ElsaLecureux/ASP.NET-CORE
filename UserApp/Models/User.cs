namespace Models {
    public class User {
        public int Id
        {get; set;}

        public string? Name
        {get; set;}

        public required UserProfile UserProfile {get; set;}
    }

}