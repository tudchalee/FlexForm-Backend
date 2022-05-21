using FlexForm_Backend.Entities;
using FlexForm_Backend.Helper;
using Microsoft.EntityFrameworkCore.Metadata;
using MongoDB.Driver;

namespace FlexForm_Backend.Services;

public interface IFlexformService
{
    List<FormStructure> GetAll();
    FormStructure GetById(string id);
    FormStructure Create(FormStructure form);
    void Update(string id, FormStructure form);
    void Remove(string id);
    
    // List<FormInput> GetAllFormInput();
    List<FormInput> GetByIdFormInput(string id);
    FormInput GetByMongoIdFormInput(string id);
    FormInput CreateFormInput(FormInput form);
    void RemoveAllByFormId(string id);
    void RemoveByMongoId(string id);
    // void UpdateIdFormInput(string id, FormInput form);
    
    List<TicketInput> GetAllTicketInput();
    List<TicketInput> GetByIdTicketInput(string id);
    List<TicketInput> GetByTicketIdTicketInput(string id);
    // TicketInput GetByMongoIdTicketInput(string id);
    TicketInput CreateTicketInput(TicketInput form);
    // void RemoveTicketByMongoId(string id);
    // void UpdateIdTicketInput(string id, TicketInput form);
}
public class FlexformServices : IFlexformService
{
    private readonly IMongoCollection<FormStructure> _formStructures;
    private readonly IMongoCollection<FormInput> _formInputs;
    private readonly IMongoCollection<TicketInput> _ticketInputs;
    public FlexformServices(FlexformDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _formStructures = database.GetCollection<FormStructure>(settings.FlexformCollectionName[0]);
        _formInputs = database.GetCollection<FormInput>(settings.FlexformCollectionName[1]);
        _ticketInputs = database.GetCollection<TicketInput>(settings.FlexformCollectionName[2]);
    }

    public FormStructure Create(FormStructure formStructure)
    {
        _formStructures.InsertOne(formStructure);
        return formStructure;
    }

    public List<FormStructure> GetAll()
     {
         return _formStructures.Find(formStructure => true).ToList();
     }

     public FormStructure GetById(string id)
     {
         return _formStructures.Find(formStructure => formStructure.FormId == id).FirstOrDefault();
     }

     public void Remove(string id)
     {
         _formStructures.DeleteOne(formStructure => formStructure.FormId == id);
     }

     public void Update(string id, FormStructure formStructure)
     {
         _formStructures.ReplaceOne(form => form.FormId == id, formStructure);
     }
     
     // Form Input
     public FormInput CreateFormInput(FormInput formInput)
     {
         _formInputs.InsertOne(formInput);
         return formInput;
     }

     // public List<FormInput> GetAllFormInput()
     // {
     //     return _formInputs.Find(formInput => true).ToList();
     // }

     public List<FormInput> GetByIdFormInput(string id)
     {
         return _formInputs.Find(formInput => formInput.FormId == id).ToList();
     }
        
     public FormInput GetByMongoIdFormInput(string id)
     {
         return _formInputs.Find(formInput => formInput.Id == id).FirstOrDefault();
     }
      
     public void RemoveAllByFormId(string id)
     {
         _formInputs.DeleteMany(formInput => formInput.FormId == id);
     }
     
     public void RemoveByMongoId(string id)
     {
         _formInputs.DeleteOne(formInput => formInput.Id == id);
     }
        
     // public void UpdateIdFormInput(string id, FormInput formInput)
     // {
     //     _formInputs.ReplaceOne(form => form.Id == id, formInput);
     // }
     
     // Ticket Input
     public TicketInput CreateTicketInput(TicketInput ticketInput)
     {
         _ticketInputs.InsertOne(ticketInput);
         return ticketInput;
     }

     public List<TicketInput> GetAllTicketInput()
     {
         return _ticketInputs.Find(ticketInput => true).ToList();
     }
     
     public List<TicketInput> GetByIdTicketInput(string id)
     {
         return _ticketInputs.Find(ticketInput => ticketInput.FormId == id).ToList();
     }
        
     public List<TicketInput> GetByTicketIdTicketInput(string id)
     {
         return _ticketInputs.Find(ticketInput => ticketInput.TicketId == id).ToList();
     }
     
     // public TicketInput GetByMongoIdTicketInput(string id)
     // {
     //     return _ticketInputs.Find(ticketInput => ticketInput.Id == id).FirstOrDefault();
     // }

     // public void RemoveTicketByMongoId(string id)
     // {
     //     _ticketInputs.DeleteOne(ticketInput => ticketInput.Id == id);
     // }
        
     // public void UpdateIdTicketInput(string id, TicketInput ticketInput)
     // {
     //     _ticketInputs.ReplaceOne(form => form.Id == id, ticketInput);
     // }
}