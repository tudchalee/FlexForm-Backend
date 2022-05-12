using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Entities;

public class TicketInput
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("FormId")] 
    public string FormId { get; set; } 
    
    [BsonElement("TicketId")] 
    public string TicketId { get; set; } 
    
    [BsonElement("InputByUser")] 
    public string InputByUser { get; set; }
    
    [BsonElement("Sections")] 
    public List<SectionTicketInput> Sections { get; set; }
    
    [BsonElement("Timestamp")] 
    public DateTime Timestamp { get; set; }
}

public class SectionTicketInput
{
    [BsonElement("SectionId")] 
    public string SectionId { get; set; } 
    
    [BsonElement("Components")] 
    public List<ComponentTicketInput> Components { get; set; }
}

public class ComponentTicketInput
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("ComponentLabel")] 
    public List<string> ComponentLabel { get; set; } 
    
    [BsonElement("ComponentValue")] 
    public List<string> ComponentValue { get; set; } 
}
