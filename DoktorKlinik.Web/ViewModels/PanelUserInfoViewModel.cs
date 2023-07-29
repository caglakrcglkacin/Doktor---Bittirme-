using DoktorKlinik.Domain.User;
using DoktorKlinik.Summary;

namespace DoktorKlinik.Web.ViewModels
{
    public class PanelUserInfoViewModel
    {
        public int Id { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName => Name + " " + Surname;
        
        public string Role { get; set; }
    }
}
