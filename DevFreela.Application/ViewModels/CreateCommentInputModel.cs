namespace DevFreela.Application.ViewModels
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }

        public int ProjectId { get; set; }
        
        public int UserId { get; set; }
    }
}
