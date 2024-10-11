namespace LibraryManagement.UI.Models.ActionRequest
{
    public class CreateBookActionRequest
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile Image { get; set; }





       
    }
}
