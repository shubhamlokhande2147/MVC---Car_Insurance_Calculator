// namespace Models
// {
//     class User_Registration
//     {
//         public User_Registration()
//         {
//         }

//         public User_Registration(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, byte[] image)
//         {
//             Id = id;
//             Name = name;
//             Age = age;
//             Mobile = mobile;
//             Aadhar_no = aadhar_no;
//             Licence_no = licence_no;
//             Address = address;
//             Gender = gender;
//             Password = password;
//             Image = image;
//         }

//         public int Id { get; set; }
//         public string Name { get; set; }
//         public int Age { get; set; }
//         public int Mobile { get; set; }
//         public int Aadhar_no { get; set; }
//         public string Licence_no { get; set; }
//         public string Address { get; set; }
//         public string Gender { get; set; }
//         public string Password { get; set; }
//         public byte[] Image { get; set; }
//     }
// }


using System.Collections.Generic;

namespace Models
{
    class User_Registration
    {
        public User_Registration()
        {
            Vehicles = new List<Vehicle>();
        }

        public User_Registration(int id, string name, int age, int mobile, int aadhar_no, string licence_no, string address, string gender, string password, byte[] image)
        {
            Id = id;
            Name = name;
            Age = age;
            Mobile = mobile;
            Aadhar_no = aadhar_no;
            Licence_no = licence_no;
            Address = address;
            Gender = gender;
            Password = password;
            Image = image;
            Vehicles = new List<Vehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Mobile { get; set; }
        public int Aadhar_no { get; set; }
        public string Licence_no { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }

  
}
