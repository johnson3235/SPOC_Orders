using Services_Layer.Custom_Validations;

namespace Services_Layer.DTOS.User
{
    public class RegisiterDTO
    {
        public string userName { get; set; }
        public string Password { get; set; }

        [ExistsProperty(ValidationModel.Role)]
        public int RoleId { get; set; }

        [ExistsProperty(ValidationModel.DM)]
        public int? ManagerId { get; set; }
    }
}
