using System;
using System.Threading.Tasks;
using System.Web.Http;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.Models.DTO;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.Api.Controllers
{
    [RoutePrefix("hrdapi/template")]
    public class TemplateController : ApiController
    {
        private readonly ITemplateRepository _template;

        public TemplateController(ITemplateRepository template)
        {
            _template = template;
        }

        // GET: api/Template
        [Route("")]
        [HttpGet]
        public async Task<TemplateDto> GetAllTemplate()
        {
            try
            {
                TemplateDto template = new TemplateDto
                {
                    ModelList = await _template.SelectAll(),
                    Status = new Status
                    {
                        Code = "Success",
                        Message = "Template"
                    }
                };
                return template;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Template/5
        [Route("{id}")]
        [HttpGet]
        public async Task<TemplateDto> GetTemplate(int? id)
        {
            try
            {
                TemplateDto template;

                if (id == null)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = "Id is not set!"
                        }
                    };
                    return template;
                }

                var model = await _template.SelectById(id);

                if (model == null)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = "Template not found!"
                        }
                    };
                    return template;
                }

                template = new TemplateDto
                {
                    ModelSingle = model,
                    Status = new Status
                    {
                        Code = "Success",
                        Message = "Complete"
                    }
                };
                return template;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("",Name = "template")]
        [HttpPost]
        public async Task<TemplateDto> PostTemplate([FromBody] Template model)
        {
            try
            {
                TemplateDto template;

                if (!ModelState.IsValid)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = string.Format("Invalid {0}", ModelState)
                        }
                    };
                    return template;
                }

                var id = await _template.Insert(model);
                string url = Url.Link("template", new { id });

                template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Success",
                        Message = string.Format("{0} {1}",url,model.TemplateId = id)
                    }
                };
                return template;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("")]
        [HttpPut]
        public async Task<TemplateDto> PutTemplate([FromBody] Template model)
        {
            try
            {
                TemplateDto template;

                if (!ModelState.IsValid)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = string.Format("Invalid {0}", ModelState)
                        }
                    };
                    return template;
                }
                var result = await _template.SelectById(model.TemplateId);
                if (result == null)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = "Template not found!"
                        }
                    };
                    return template;
                }
                await _template.Update(model);

                template = new TemplateDto
                {
                    ModelSingle = model,
                    Status = new Status
                    {
                        Code = "Success",
                        Message = "Update Successfull"
                    }
                };
                return template;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<TemplateDto> DeleteTemplate(int? id)
        {
            try
            {
                TemplateDto template;

                if (id == null)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = "Id is not set!"
                        }
                    };
                    return template;
                }

                var model = await _template.SelectById(id);

                if (model == null)
                {
                    template = new TemplateDto
                    {
                        Status = new Status
                        {
                            Code = "Error",
                            Message = "Template not found!"
                        }
                    };
                    return template;
                }

                await _template.Delete(id);

                template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Success",
                        Message = string.Format("Delete id={0} Complete", id)
                    }
                };

                return template;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("identity/")]
        [HttpGet]
        public async Task<IdentityDto> GetTemplateId()
        {
            try
            {
                IdentityDto identity = new IdentityDto
                {
                    Status = new Status
                    {
                        Code = "Success",
                        Message = "Template Identity"
                    },
                    ModelSingle = await _template.TemplateGetIdentity()
                };
                return identity;
            }
            catch (Exception ex)
            {
                
                IdentityDto identity = new IdentityDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = string.Format("Template exception {0}",ex.Message)
                    }
                };
                return identity;
            }
        } 
    }
}
