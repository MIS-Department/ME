using System.Threading.Tasks;
using Shared.Models.DTO;
using Shared.Models.Tables;

namespace Shared.DataLayer.Interfaces.IServices
{
    public interface ITemplateService : IDefaultService<TemplateDto, Template>
    {
        Task<IdentityDto> TemplateGetIdentity();
    }
}
