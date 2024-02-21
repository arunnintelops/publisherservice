using MediatR;

namespace Application.Commands.PublisherService
{
    public class UpdatePublisherCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string Address { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public string Phone { get; set; }
        
    
    }
}
