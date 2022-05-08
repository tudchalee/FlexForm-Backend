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
    public List<ComponentFormInput> Components { get; set; }
}

public class ComponentFormInput
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("ComponentLabel")] 
    public List<string> ComponentLabel { get; set; } 
    
    [BsonElement("ComponentValue")] 
    public List<string> ComponentValue { get; set; } 
}

public class UserInfo
{
    public string UserName { get; set; }

    public int Age { get; set; }
}

public class DemoResponse<T>  
{  
    public int Code { get; set; }  
  
    public string Msg { get; set; }  
  
    public T Data { get; set; }  
  
    public static DemoResponse<T> GetResult(int code, string msg, T data = default(T))  
    {  
        return new DemoResponse<T>  
        {  
            Code = code,  
            Msg = msg,  
            Data = data  
        };  
    }  
}  