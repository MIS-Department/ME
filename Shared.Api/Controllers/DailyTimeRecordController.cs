using System;
using System.Threading.Tasks;
using System.Web.Http;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.Models.DTO;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.Api.Controllers
{
    [RoutePrefix("hrdapi/timerecord")]
    public class DailyTimeRecordController : ApiController
    {
        private readonly IDailyTimeRecordRepository _dailyTimeRecordRepo;
        private readonly IEmployeeRepository _employeeRepository;

        public DailyTimeRecordController(IDailyTimeRecordRepository dailyTimeRecordRepo,
            IEmployeeRepository employeeRepository)
        {
            _dailyTimeRecordRepo = dailyTimeRecordRepo;
            _employeeRepository = employeeRepository;
        }


        // GET: api/DailyTimeRecord
        [Route("")]
        [HttpGet]
        public async Task<EmployeeNotifyDto> GetEmployeeDetails([FromUri] string employeeNumber,
            [FromUri] int? timeCategoryId)
        {
            EmployeeNotifyDto employeeNoitfy;

            if (employeeNumber == null || timeCategoryId == null)
            {
                employeeNoitfy = new EmployeeNotifyDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "Emplyee Number or Time Category Id is not set!"
                    }
                };
                return employeeNoitfy;
            }

            int? employeeId = await _dailyTimeRecordRepo.SelectByEmployeeNumber(employeeNumber);

            if (employeeId == null)
            {
                employeeNoitfy = new EmployeeNotifyDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "Employee Number do not exist!"
                    }
                };
                return employeeNoitfy;
            }

            var notify = await _dailyTimeRecordRepo.GetEmployeeNotification(employeeId, timeCategoryId);

            employeeNoitfy = new EmployeeNotifyDto
            {
                IsSuspended = notify.IsSuspended,
                IsResign = notify.IsResign,
                IsTimeCheck = notify.IsTimeCheck,
                Employee = await _employeeRepository.SelectById(employeeId),
                DailyTimeRecord = await _dailyTimeRecordRepo.GetDailyTimeRecordTopFive(employeeId)
            };

            if (employeeNoitfy.IsResign)
            {
                employeeNoitfy.Status = new Status
                {
                    Code = "Error",
                    Message = "Employee is Resign!"
                };
                return employeeNoitfy;
            }
            if (employeeNoitfy.IsSuspended)
            {
                employeeNoitfy.Status = new Status
                {
                    Code = "Error",
                    Message = "Employee is Suspended!"
                };
                return employeeNoitfy;
            }
            if (employeeNoitfy.IsTimeCheck)
            {
                employeeNoitfy.Status = new Status
                {
                    Code = "Error",
                    Message = "Have already record"
                };
                return employeeNoitfy;
            }

            var model = new DailyTimeRecord
            {
                DateCreated = DateTime.Now,
                EmployeeId = employeeId,
                TimeCategoryId = timeCategoryId,
                Time = DateTime.Now
            };

            await _dailyTimeRecordRepo.Insert(model);

            employeeNoitfy.DailyTimeRecord = await _dailyTimeRecordRepo.GetDailyTimeRecordTopFive(employeeId);
            employeeNoitfy.Status = new Status
            {
                Code = "Success",
                Message = "Complete!"
            };

            return employeeNoitfy;
        }

        [HttpGet]
        [Route("")]
        public async Task<DailyTimeRecordDto> GetAllDailyTimeRecord()
        {
            DailyTimeRecordDto dailyTime = new DailyTimeRecordDto
            {
                ModelList = await _dailyTimeRecordRepo.SelectAll(),
                Status = new Status
                {
                    Code = "Success",
                    Message = "Daily Time Record"
                }
            };
            return dailyTime;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<DailyTimeRecordDto> GetDailyTimeRecord(int? id)
        {
            DailyTimeRecordDto dailyTime;

            if (id == null)
            {
                dailyTime = new DailyTimeRecordDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "Id is not set"
                    }
                };
                return dailyTime;
            }

            var model = await _dailyTimeRecordRepo.SelectById(id);

            if (model == null)
            {
                dailyTime = new DailyTimeRecordDto
                {
                    Status = new Status
                    {
                        Code = "Bad Request",
                        Message = "No Record Found!"
                    }
                };
                return dailyTime;
            }

            dailyTime = new DailyTimeRecordDto
            {
                ModelSingle = model,
                Status = new Status
                {
                    Code = "Success",
                    Message = "Daily Time Record!"
                }
            };

            return dailyTime;
        }

        [HttpPost]
        [Route("", Name = "dailytimerecord")]
        public async Task<DailyTimeRecordDto> PostDailyTimeRecord([FromBody] DailyTimeRecord model)
        {
            DailyTimeRecordDto dailyTime;

            if (!ModelState.IsValid)
            {
                dailyTime = new DailyTimeRecordDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = string.Format("Invalid {0}!", ModelState)
                    }
                };
                return dailyTime;
            }
            var id = await _dailyTimeRecordRepo.Insert(model);
            string url = Url.Link("dailytimerecord", new { id });

            dailyTime = new DailyTimeRecordDto
            {
                Status = new Status
                {
                    Code = "Success",
                    Message = string.Format("{0} {1}",url, model.DailyTimeRecordId = id)
                }
            };
            return dailyTime;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<DailyTimeRecordDto> DeleteDailyTimeRecord(int? id)
        {
            DailyTimeRecordDto dailyTime;
            if (id == null)
            {
                dailyTime = new DailyTimeRecordDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "Id is not set!"
                    }
                };
                return dailyTime;
            }
            var model = await _dailyTimeRecordRepo.SelectById(id);
            if (model == null)
            {
                dailyTime = new DailyTimeRecordDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "No Record Found!"
                    }
                };
                return dailyTime;
            }

            await _dailyTimeRecordRepo.Delete(id);
            dailyTime = new DailyTimeRecordDto
            {
                Status = new Status
                {
                    Code = "Success",
                    Message = string.Format("Delete id={0} Complete!", id)
                }
            };
            return dailyTime;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dailyTimeRecordRepo.Dispose();    
            }
        }
    }
}
