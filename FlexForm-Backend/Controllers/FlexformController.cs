using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using FlexForm_Backend.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using OfficeOpenXml;

namespace FlexForm_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlexformController : ControllerBase
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
        var forminput = flexformService.GetByIdFormInput(id);
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        flexformService.Remove(form.FormId);
        if (forminput.Count != 0)
        {
            flexformService.RemoveAllByFormId(forminput[0].FormId);
        }

        return Ok($"Form with Id = {id} deleted");
    }

    // Form Input
    // // GET: api/FlexInput/AllForm
    // [HttpGet("FormInput/AllFormInput")]
    // public ActionResult<List<FormInput>> GetAllFormInput()
    // {
    //     return flexformService.GetAllFormInput();
    // }

    // GET api/FormInput/FormInput/{id}
    [HttpGet("FormInput/FormInput/{id}")]
    public ActionResult<List<FormInput>> GetByIdFormInput(string id)
    {
        var form = flexformService.GetByIdFormInput(id);

        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        return form;
    }

    // GET api/FormInput/Mongo/{id}
    // [HttpGet("FormInput/Mongo/{id}")]
    // public ActionResult<FormInput> GetByMongoIdFormInput(string id)
    // {
    //     var form = flexformService.GetByMongoIdFormInput(id);
    //
    //     if (form == null)
    //     {
    //         return NotFound($"Form with Id = {id} not found");
    //     }
    //
    //     return form;
    // }

    // POST api/FormInput/CreateForm
    [HttpPost("FormInput/CreateFormInput")]
    public ActionResult<FormInput> Post([FromBody] FormInput form)
    {
        var savedForm = flexformService.CreateFormInput(form);
        return savedForm;
    }

    //DELETE api/FormInput/Delete/Mongo/{id}
    [HttpDelete("FormInput/Delete/Mongo/{id}")]
    public ActionResult DeleteMongo(string id)
    {
        var form = flexformService.GetByMongoIdFormInput(id);
    
        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }
    
        flexformService.RemoveByMongoId(form.Id);
    
        return Ok($"Form with Id = {id} deleted");
    }

    // // PUT api/FormInput/{id}
    // [HttpPut("FormInput/{id}")]
    // public ActionResult Put(string id, [FromBody] FormInput form)
    // {
    //     var existingForm = flexformService.GetByMongoIdFormInput(id);
    //
    //     if (existingForm == null)
    //     {
    //         return NotFound($"Form with Id = {id} not found");
    //     }
    //
    //     flexformService.UpdateIdFormInput(id, form);
    //     return NoContent();
    // }

    // Ticket Input
    // GET: api/Ticket/AllTicketInput
    [HttpGet("TicketInput/AllTicketInput")]
    public ActionResult<List<TicketInput>> GetAllTicketInput()
    {
        return flexformService.GetAllTicketInput();
    }

    // GET api/TicketInput/{id}
    [HttpGet("TicketInput/{id}")]
    public ActionResult<List<TicketInput>> GetByIdTicketInput(string id)
    {
        var form = flexformService.GetByIdTicketInput(id);

        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        return form;
    }

    [HttpGet("TicketInput/TicketId/{id}")]
    public ActionResult<List<TicketInput>> GetByTicketIdTicketInput(string id)
    {
        var form = flexformService.GetByTicketIdTicketInput(id);

        if (form == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        return form;
    }

    // // GET api/TicketInput/Mongo/{id}
    // [HttpGet("TicketInput/Mongo/{id}")]
    // public ActionResult<TicketInput> GetByMongoIdTicketInput(string id)
    // {
    //     var form = flexformService.GetByMongoIdTicketInput(id);
    //
    //     if (form == null)
    //     {
    //         return NotFound($"Form with Id = {id} not found");
    //     }
    //
    //     return form;
    // }

    // POST api/TicketInput/CreateForm
    [HttpPost("TicketInput/CreateTicketInput")]
    public ActionResult<TicketInput> Post([FromBody] TicketInput form)
    {
        var savedForm = flexformService.CreateTicketInput(form);
        return savedForm;
    }

    // //DELETE api/TicketInput/Delete/Mongo/{id}
    // [HttpDelete("TicketInput/Delete/Mongo/{id}")]
    // public ActionResult DeleteTicketMongo(string id)
    // {
    //     var form = flexformService.GetByMongoIdTicketInput(id);
    //
    //     if (form == null)
    //     {
    //         return NotFound($"Form with Id = {id} not found");
    //     }
    //
    //     flexformService.RemoveTicketByMongoId(form.Id);
    //
    //     return Ok($"Form with Id = {id} deleted");
    // }

    // // PUT api/TicketInput/{id}
    // [HttpPut("TicketInput/{id}")]
    // public ActionResult Put(string id, [FromBody] TicketInput form)
    // {
    //     var existingForm = flexformService.GetByMongoIdTicketInput(id);
    //
    //     if (existingForm == null)
    //     {
    //         return NotFound($"Form with Id = {id} not found");
    //     }
    //
    //     flexformService.UpdateIdTicketInput(id, form);
    //     return NoContent();
    // }

    // Export
    [HttpGet("exportBasic")]
    public async Task<IActionResult> ExportBasic(string id)
    {
        var formStructure = flexformService.GetById(id);
        var responses = flexformService.GetByIdFormInput(id);

        if (responses == null)
        {
            return NotFound($"Form with Id = {id} not found");
        }

        List<string> componentLabels = new List<string>();

        foreach (var section in formStructure.Sections)
        {
            foreach (var component in section.Components)
            {
                if (component.ComponentType != "heading" && component.ComponentType != "paragraph")
                {
                    componentLabels.Add(component.ComponentProperties.LabelText);
                }
            }
        }

        var keyValList = new List<Dictionary<string, string>>();

        foreach (var response in responses)
        {
            var resKV = new Dictionary<string, string>();
            foreach (var section in response.Sections)
            {
                foreach (var component in section.Components)
                {
                    resKV.Add(component.ComponentLabel[0], String.Join(", ", component.ComponentValue));
                }
            }

            var kv = new Dictionary<string, string>();
            foreach (var key in componentLabels)
            {
                if (resKV.ContainsKey(key))
                {
                    kv.Add(key, resKV[key]);
                }
                else
                    kv.Add(key, String.Empty);
            }

            keyValList.Add(kv);
        }

        // query data from database  
        await Task.Yield();
        var stream = new MemoryStream();

        using (var package = new ExcelPackage(stream))
        {
            var workSheet = package.Workbook.Worksheets.Add("Sheet1");

            DataTable dataTable = new DataTable();
            DataRow row;

            foreach (var label in componentLabels)
            {
                dataTable.Columns.Add(label);
            }

            foreach (var kvRow in keyValList)
            {
                row = dataTable.NewRow();
                foreach (var key in componentLabels)
                {
                    row[key] = kvRow[key];
                }

                dataTable.Rows.Add(row.ItemArray);
            }

            workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);

            package.Save();
        }

        stream.Position = 0;
        string excelName = formStructure.FormName + ".xlsx";

        //return File(stream, "application/octet-stream", excelName);  
        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
    }
}
    
