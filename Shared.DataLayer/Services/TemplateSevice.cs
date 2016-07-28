using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Shared.DataLayer.Interfaces.IServices;
using Shared.DataLayer.Util;
using Shared.Models.DTO;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.DataLayer.Services
{
    public class TemplateSevice : ITemplateService
    {
        private readonly HttpClient _client;
        private TemplateDto _template;

        public TemplateSevice()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(UrlString.BaseAddress());
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<TemplateDto> SelectAll()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("/hrdapi/template/");

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TemplateDto>();
            }
            catch (Exception ex)
            {
                _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
                return _template;
            }
        }

        public async Task<TemplateDto> SelectById(int? id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("/hrdapi/template/" + id);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<TemplateDto>();
            }
            catch (Exception ex)
            {
                _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
                return _template;
            }
        }

        public async Task<TemplateDto> Insert(Template model)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync("/hrdapi/template/", model);
                response.EnsureSuccessStatusCode();

                return _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Success",
                        Message = string.Format("Insert ")
                    }
                };
            }
            catch (Exception ex)
            {
                return _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
            }
        }

        public async Task<TemplateDto> Delete(int? id)
        {

            try
            {
                HttpResponseMessage reponse = await _client.DeleteAsync("/hrdapi/template/" + id);
                reponse.EnsureSuccessStatusCode();

                return _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Success",
                        Message = string.Format("Delete id={0} Complete", id)
                    }
                };
            }
            catch (Exception ex)
            {
                return _template = new TemplateDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
            }
        }

        public async Task<TemplateDto> Update(Template model)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityDto> TemplateGetIdentity()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("/hrdapi/template/identity");

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IdentityDto>();
            }
            catch (Exception ex)
            {
                var identity = new IdentityDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = string.Format("Template Identity exception={0}", ex.Message)
                    }
                };
                return identity;
            }
        }
    }
}
