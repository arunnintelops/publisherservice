using MediatR;

namespace Application.Commands.PublisherService
{
    public class CreatePublisherCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string Address { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public string Phone { get; set; }
        
    
    }
}
