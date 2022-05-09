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
    
    List<FormInput> GetAllFormInput();
    List<FormInput> GetByIdFormInput(string id);
    FormInput GetByMongoIdFormInput(string id);
    FormInput CreateFormInput(FormInput form);
    void RemoveByMongoId(string id);
    void UpdateIdFormInput(string id, FormInput form);
}
public class FlexformServices : IFlexformService
{
    private readonly IMongoCollection<FormStructure> _formStructures;
    private readonly IMongoCollection<FormInput> _formInputs;
    public FlexformServices(FlexformDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _formStructures = database.GetCollection<FormStructure>(settings.FlexformCollectionName[0]);
        _formInputs = database.GetCollection<FormInput>(settings.FlexformCollectionName[1]);
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

     public List<FormInput> GetAllFormInput()
     {
         return _formInputs.Find(formInput => true).ToList();
     }

     public List<FormInput> GetByIdFormInput(string id)
     {
         return _formInputs.Find(formInput => formInput.FormId == id).ToList();
     }
        
     public FormInput GetByMongoIdFormInput(string id)
     {
         return _formInputs.Find(formInput => formInput.Id == id).FirstOrDefault();
     }
        
     public void RemoveByMongoId(string id)
     {
         _formInputs.DeleteOne(formInput => formInput.Id == id);
     }
        
     public void UpdateIdFormInput(string id, FormInput formInput)
     {
         _formInputs.ReplaceOne(form => form.Id == id, formInput);
     }
}