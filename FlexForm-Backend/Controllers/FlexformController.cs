using System.Text;
using FlexForm_Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace FlexForm_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlexformController: ControllerBase
{
    private readonly IFlexformService flexformService;
    public FlexformController(IFlexformService flexformService)
    {
        this.flexformService = flexformService;
    }

    // GET: api/Flexform/AllForm
    [HttpGet("AllForm")]
    public ActionResult<List<FormStructure>> GetAll()
    {
        return flexformService.GetAll();
    }

    // GET api/Flexform/{id}
    [HttpGet("{id}")]
    public ActionResult<FormStructure> GetById(string id)
    {
        var form = flexformService.GetById(id);
    
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
    
        return form;
    }
    
    // POST api/Flexform/CreateForm
    [HttpPost("CreateForm")]
    public ActionResult<FormStructure> Post([FromBody] FormStructure form)
    {
        var savedForm = flexformService.Create(form);
        return savedForm;
    }
    
    // PUT api/Flexform/{id}
    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] FormStructure form)
    {
        var existingForm = flexformService.GetById(id);
    
        if (existingForm == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        flexformService.Update(id, form);
        return NoContent();
    }
    
    // DELETE api/Flexform/{id}
    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        var form = flexformService.GetById(id);
    
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
        
        flexformService.Remove(form.FormId);
    
        return Ok($"Form with Id = {id} deleted");
    }
}

[Route("api/[controller]")]
[ApiController]
public class FormInputController : ControllerBase
{
    private readonly IFormInputService forminputService;

    public FormInputController(IFormInputService forminputService)
    {
        this.forminputService = forminputService;
    }
    
        
    // GET: api/FlexInput/AllForm
    [HttpGet("AllFormInput")]
    public ActionResult<List<FormInput>> GetAllFormInput()
    {
        return forminputService.GetAllFormInput();
    }

    // GET api/FormInput/FormInput/{id}
    [HttpGet("FormInput/{id}")]
    public ActionResult<List<FormInput>> GetByIdFormInput(string id)
    {
        var form = forminputService.GetByIdFormInput(id);
    
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
    
        return form;
    }
    
    // GET api/FormInput/Mongo/{id}
    [HttpGet("Mongo/{id}")]
    public ActionResult<FormInput> GetByMongoIdFormInput(string id)
    {
        var form = forminputService.GetByMongoIdFormInput(id);
    
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
    
        return form;
    }
    
    // POST api/FormInput/CreateForm
    [HttpPost("CreateFormInput")]
    public ActionResult<FormInput> Post([FromBody] FormInput form)
    {
        var savedForm = forminputService.CreateFormInput(form);
        return savedForm;
    }
    
    //DELETE api/FormInput/Delete/Mongo/{id}
    [HttpDelete("Delete/Mongo/{id}")]
    public ActionResult Delete(string id)
    {
        var form = forminputService.GetByMongoIdFormInput(id);
        Console.WriteLine("Hello" + form);
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
        
        forminputService.RemoveByMongoId(form.Id);
    
        return Ok($"Form with Id = {id} deleted");
    }
}


[Route("api/[controller]")]
[ApiController]
public class ImportExportController : ControllerBase
{
    [HttpGet("Import")]
    public string Import()
    {
        string sWebRootFolder = @"D:\";
        string sFileName = @"UserList-25650506145952547.xlsx";
        FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
        try
        {
            using (ExcelPackage package = new ExcelPackage(file))
            {
                StringBuilder sb = new StringBuilder();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                bool bHeaderRow = true;
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= ColCount; col++)
                    {
                        if (bHeaderRow)
                        {
                            sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                        }
                        else
                        {
                            sb.Append(worksheet.Cells[row, col].Value.ToString() + "\t");
                        }
                    }

                    sb.Append(Environment.NewLine);
                }

                return sb.ToString();
            }
        }
        catch (Exception ex)
        {
            return "Some error occured while importing." + ex.Message;
        }
    }

    public List<ComponentFormInput> itemlist;
        
    [HttpGet("exportv2")]
    public async Task<IActionResult> ExportV2(CancellationToken cancellationToken)
    {
        // query data from database  
        await Task.Yield();
        var list = new List<UserInfo>()
        {
            new UserInfo {UserName = "catcher", Age = 18},
            new UserInfo {UserName = "james", Age = 20},
        };
        

        var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                for (int i = 0; i < itemlist.Count; i++)
                {
                    var item = itemlist[i];
                    workSheet.Cells[i + 2, 1].Value = item.ComponentValue;
                }
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        [HttpGet("export")]
        public async Task<DemoResponse<string>> Export(CancellationToken cancellationToken)
        {
            string folder = @"D:\Download";
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            string downloadUrl = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, excelName);
            FileInfo file = new FileInfo(Path.Combine(folder, excelName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(Path.Combine(folder, excelName));
            }

            // query data from database  
            await Task.Yield();

            var list = new List<UserInfo>()
            {
                new UserInfo {UserName = "catcher", Age = 18},
                new UserInfo {UserName = "james", Age = 20},
            };

            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }

            return DemoResponse<string>.GetResult(0, "OK", downloadUrl);
        }
    }


