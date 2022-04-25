using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Models;

public class FormStructures
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("FormId")] 
    public string FormId { get; set; }
    
    [BsonElement("FormName")] 
    public string FormName { get; set; }
    
    [BsonElement("FormCreateTimestamp")] 
    public BsonTimestamp FormCreateTimestamp { get; set; }
    
    [BsonElement("FormModifiedTimestamp")] 
    public BsonTimestamp FormModifiedTimestamp { get; set; }
    
    [BsonElement("CreateByUser")] 
    public string CreateByUser { get; set; }
    
    [BsonElement("ModifyByUser")] 
    public string ModifyByUser { get; set; }
    
    [BsonElement("Template")] 
    public bool Template { get; set; }
    
    [BsonElement("ActionButton")] 
    public List<ActionButton> ActionButton { get; set; } 
    
    [BsonElement("Sections")] 
    public List<Sections> Sections { get; set; }
    
    [BsonElement("Component")] 
    public List<ComponentFormStructure> ComponentFormStructure { get; set; }
}

public class ActionButton
{
    [BsonElement("ActionButtonName")]
    public string ActionButtonName { get; set; }
    
    [BsonElement("ActionButtonProperties")]
    public List<ActionButtonProperties> ActionButtonProperties { get; set; }
}

public class ActionButtonProperties
{
    
    [BsonElement("FontColor")]
    public string FontColor { get; set; }
    
    [BsonElement("BackgroundColor")]
    public string BackgroundColor { get; set; }
}

public class Sections
{
    [BsonElement("SectionId")]
    public string SectionId { get; set; } 
    
    [BsonElement("SectionName")]
    public string SectionName { get; set; } 
    
    [BsonElement("SectionIndex")]
    public int SectionIndex { get; set; }

    [BsonElement("SectionProperties")]
    public List<SectionProperties> SectionProperties { get; set; } 
}

public class SectionProperties
{
    [BsonElement("FontName")] 
    public string FontName { get; set; } 

    [BsonElement("FontSize")] 
    public int FontSize { get; set; } 
        
    [BsonElement("FontColor")]
    public string FontColor { get; set; }

    [BsonElement("BackgroundColor")]
    public string BackgroundColor { get; set; }
}

public class ComponentFormStructure
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("ComponentIndex")] 
    public int ComponentIndex { get; set; } 
    
    [BsonElement("ComponentLabel")] 
    public string ComponentLabel { get; set; } 
    
    [BsonElement("ComponentType")] 
    public string ComponentType { get; set; }

    [BsonElement("ComponentProperties")] 
    public List<ComponentProperties> ComponentProperties { get; set; } 
    
    [BsonElement("ComponentTemplate")] 
    public bool ComponentTemplate { get; set; } 
}

public class ComponentProperties
{
    [BsonElement("HeadingText")]
    public string HeadingText { get; set; }
    
    [BsonElement("SubheadingText")]
    public string SubheadingText { get; set; }
    
    [BsonElement("Alignment")]
    public string Alignment { get; set; }
    
    [BsonElement("HeadingFontColor")]
    public string HeadingFontColor { get; set; } 
    
    [BsonElement("SubheadingFontColor")]
    public string SubheadingFontColor { get; set; } 
    
    [BsonElement("HeadingFontSize")]
    public int HeadingFontSize { get; set; } 
    
    [BsonElement("SubheadingFontSize")]
    public int SubheadingFontSize { get; set; }

    [BsonElement("Validation")]
    public List<Validation> Validation { get; set; }
}

public class Validation
{
    [BsonElement("Day")]
    public string Day { get; set; }
    
    [BsonElement("Gender")]
    public string Gender { get; set; }
        
    [BsonElement("Month")]
    public string Month { get; set; }
    
    [BsonElement("Priority")]
     public string Priority { get; set; }
            
    [BsonElement("Status")]
     public string Status { get; set; }
}

