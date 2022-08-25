using Microsoft.AspNetCore.Mvc;
using VarApp.Core.Contracts;
using VarApp.Core.Models.Detailing;

namespace VarApp.Api.Controllers
{
    [ApiController]
    public class DetailingController : ControllerBase
    {
        private readonly IDetailingService _detailingService;

        public DetailingController(IDetailingService detailingService)
        {
            _detailingService = detailingService;
        }

       
        public record WorkbookRequest(DetailingType Type, IReadOnlyCollection<DetailingProp> props);

        [HttpPost]
        [Route("api/detailing/workbook")]
        public async Task<ActionResult> GetWorkbook([FromBody]WorkbookRequest request)
        {
            using MemoryStream stream = new();

            _detailingService.GetWorkbook(request.Type, request.props, stream);
            stream.Seek(0, SeekOrigin.Begin);

            return File(
                fileContents: stream.ToArray(),
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Workbook.xlsx");
        }

    }
}
