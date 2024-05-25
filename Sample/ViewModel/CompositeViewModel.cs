namespace Sample.ViewModel
{
    public class CompositeViewModel
    {
        //public IEnumerable<SummaryViewModel> CollectionSummaryModel { get; set; }

        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
