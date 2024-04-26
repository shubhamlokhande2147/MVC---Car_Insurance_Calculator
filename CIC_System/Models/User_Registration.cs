namespace Models
{
    class User_Registration
    {
        public User_Registration()
        {

        }
        
        public User_Registration(int id, string name, int mobile, string address, string gender, string password, byte[] image)
        {
            Id = id;
            Name = name;
            Mobile = mobile;
            Address = address;
            Gender = gender;
            Password = password;
            Image = image;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
    }
}
