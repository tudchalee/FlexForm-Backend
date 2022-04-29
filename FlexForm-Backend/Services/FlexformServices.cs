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
}
public class FlexformServices : IFlexformService
{
    private readonly IMongoCollection<FormStructure> _formStructures;
    public FlexformServices(FlexformDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _formStructures = database.GetCollection<FormStructure>(settings.FlexformCollectionName[0]);
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
}