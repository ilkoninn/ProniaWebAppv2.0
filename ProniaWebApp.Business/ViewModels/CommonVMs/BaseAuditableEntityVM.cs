namespace ProniaWebApp.MVC.Areas.Manage.ManageViewModels.CommonVMs
{
    public class BaseAuditableEntityVM : BaseEntityVM
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
