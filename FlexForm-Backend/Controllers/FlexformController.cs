using FlexForm_Backend.Entities;
using Microsoft.AspNetCore.Mvc;

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
    

