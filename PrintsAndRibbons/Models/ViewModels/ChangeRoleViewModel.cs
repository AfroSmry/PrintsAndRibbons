using Microsoft.AspNetCore.Identity;
using PrintsAndRibbons.Models.Accounts;

namespace PrintsAndRibbons.Models.ViewModels
{
    public class ChangeRoleViewModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string UserEmail { get; set; }
        public List<Role> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<Role>();
            UserRoles = new List<string>();
        }
    }
}
