using System.Text;
using FlexForm_Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
    
        
    // GET: api/Flexform/AllForm
    [HttpGet("AllFormInput")]
    public ActionResult<List<FormInput>> GetAllFormInput()
    {
        return forminputService.GetAllFormInput();
    }

    // GET api/Flexform/FormInput/{id}
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
    
    // POST api/Flexform/CreateForm
    [HttpPost("CreateFormInput")]
    public ActionResult<FormInput> Post([FromBody] FormInput form)
    {
        var savedForm = forminputService.CreateFormInput(form);
        return savedForm;
    }
}

[Route("api/[controller]")]
[ApiController]
public class ImportExportController : ControllerBase
 {
  private readonly IHostingEnvironment _hostingEnvironment;

  public ImportExportController(IHostingEnvironment hostingEnvironment)
  {
   _hostingEnvironment = hostingEnvironment;
  }
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
 }
    

