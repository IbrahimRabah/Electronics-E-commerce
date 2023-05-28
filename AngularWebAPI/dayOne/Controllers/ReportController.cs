using dayOne.DTO;
using dayOne.Models;
using dayOne.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportRepository reportRepository;
        public ReportController(
                          IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet("GetAllReports")]
        public IEnumerable<ReportDto> GetAllReports()
        {
            List<ReportDto> reportDto = new List<ReportDto>();
            List<Report> report = (List<Report>)reportRepository.GetAll(x => x.isDeleted == false);

            foreach(Report r in report)
            {
                reportDto.Add(
                    new ReportDto()
                    {
                        Id = r.Id,
                        CustomerId = r.CustomerId,
                        ReviewBody = r.ReviewBody,
                    });

            }

            return reportDto;




        }



        [HttpPost("AddReport")]
        public void AddReport(ReportDto reportdto)
        {
           if(ModelState.IsValid)
            {
                Report report = new Report();   
               // report.Id = reportdto.Id;
                    
                report.ReviewBody= reportdto.ReviewBody;
                report.CustomerId= reportdto.CustomerId;
              
                reportRepository.Add(report);

            }


        }






    }
}
