using System.ComponentModel.DataAnnotations;

namespace day8solid.ViewModels
{
    public class loginVM
    {

        public string UserName { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool remember_password { get; set; }


    }
}
