namespace Models {
    public class UserProfile {
        public int Id
        {get; set;}

        public string? Biography
        {get; set;}

        public string? Avatar
        {get; set;}

        public int UserId {get; set;}
        public required User User {get; set;}
    }

}