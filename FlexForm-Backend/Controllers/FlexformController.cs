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
    
    // GET: api/<FlexformController>
    [HttpGet]
    public ActionResult<List<FormStructure>> GetAll()
    {
        return flexformService.GetAll();
    }

    // GET api/<FlexformController>/5
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
    
    // POST api/<FlexformController>/5
    [HttpPost]
    public ActionResult<FormStructure> Post([FromBody] FormStructure form)
    {
        var savedForm = flexformService.Create(form);
        return savedForm;
        
        // flexformService.Create(form);
        // return CreatedAtAction(nameof(Get), new {id = form.FormId}, form)
    }
    
    // PUT api/<FlexformController>/5
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
    
    // DELETE api/<FlexformController>/5
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