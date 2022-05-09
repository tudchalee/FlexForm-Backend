using FlexForm_Backend.Entities;
using FlexForm_Backend.Models;
using FlexForm_Backend.Helper;
using Microsoft.EntityFrameworkCore.Metadata;
using MongoDB.Driver;

namespace FlexForm_Backend.Services;
public interface IFormInputService
{
    List<FormInput> GetAllFormInput();
    List<FormInput> GetByIdFormInput(string id);
    FormInput GetByMongoIdFormInput(string id);
    FormInput CreateFormInput(FormInput form);
    void RemoveByMongoId(string id);
    // ImportExport GetExport();
}
public class FormInputServices : IFormInputService
{
    private readonly IMongoCollection<FormInput> _formInputs;
    public FormInputServices(FlexformDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _formInputs = database.GetCollection<FormInput>(settings.FlexformCollectionName[1]);
    }

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

    // public ImportExport GetExport()
    // {
    //     return WebRootPath;
    // }
}