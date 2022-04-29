using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Entities;

public class FormInput
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("FormId")] 
    public string FormId { get; set; } 
    
    [BsonElement("InputByUser")] 
    public string InputByUser { get; set; }
    
    [BsonElement("Sections")] 
    public List<SectionFormInput> Sections { get; set; }
    
    [BsonElement("Timestamp")] 
    public DateTime Timestamp { get; set; }
}

public class SectionFormInput
{
    [BsonElement("SectionId")] 
    public string SectionId { get; set; } 
    
    [BsonElement("Components")] 
    public List<ComponentFormInput> ComponentFormInput { get; set; }
}

public class ComponentFormInput
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("ComponentValue")] 
    public List<string> ComponentValue { get; set; } 
}