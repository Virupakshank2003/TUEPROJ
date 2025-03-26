using TUEPROJ.Domain.Enums;

namespace TUEPROJ.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public bool Status { get; set; }

        public void ToggleStatus()
        {
            Status = !Status;
        }


    }

    

   


}
