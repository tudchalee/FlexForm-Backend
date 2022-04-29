using FlexForm_Backend.Entities;
using FlexForm_Backend.Helper;
using Microsoft.EntityFrameworkCore.Metadata;
using MongoDB.Driver;

namespace FlexForm_Backend.Services;

public interface IFormInputService
{
    List<FormInput> GetAllFormInput();
    FormInput GetByIdFormInput(string id);
    FormInput CreateFormInput(FormInput form);
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

    public FormInput GetByIdFormInput(string id)
    {
        return _formInputs.Find(formInput => formInput.FormId == id).FirstOrDefault();
    }
}