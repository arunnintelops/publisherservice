using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Publisher : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string Address { get; set; }
        
    
        
        public string Name { get; set; }
        
    
        
        public string Phone { get; set; }
        
    
    }
}
