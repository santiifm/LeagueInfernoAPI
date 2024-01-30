using System.Threading.Tasks;

namespace league_inferno_api.Models
{
    public class Role : BaseEntity
    {
        public required string Name { get; set; }
    }
}