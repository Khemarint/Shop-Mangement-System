using System;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public bool? IsAdmin { get; set; }
    public byte[] Image { get; set; } 

   
    public User(string name, string email, string password, string address, DateTime dateOfBirth, string gender, string phoneNumber, bool? isAdmin, byte[] image) 
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Address = address;
        this.DateOfBirth = dateOfBirth;
        this.Gender = gender;
        this.PhoneNumber = phoneNumber;
        this.IsAdmin = isAdmin;
        this.Image = image; 
    }
}

