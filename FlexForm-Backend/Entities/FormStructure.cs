using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Entities;

// [BsonIgnoreExtraElements]
public class FormStructure
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("FormId")] 
    public string FormId { get; set; }
    
    [BsonElement("TicketId")] 
    public string TicketId { get; set; }
    
    [BsonElement("FormName")] 
    public string FormName { get; set; }
    
    [BsonElement("FormDescriptions")] 
    public string FormDescriptions { get; set; }
    
    [BsonElement("FormCreatedTimestamp")] 
    public DateTime FormCreatedTimestamp { get; set; }
    
    [BsonElement("FormModifiedTimestamp")] 
    public DateTime FormModifiedTimestamp { get; set; }
    
    [BsonElement("CreatedByUser")] 
    public string CreatedByUser { get; set; }
    
    [BsonElement("ModifiedByUser")] 
    public string ModifiedByUser { get; set; }
    
    [BsonElement("UseTemplate")] 
    public bool UseTemplate { get; set; }
    
    [BsonElement("ActionButton")] 
    public ActionButtons ActionButton { get; set; } 
    
    [BsonElement("Sections")] 
    public List<Section> Sections { get; set; }
}

public class ActionButtons
{
    [BsonElement("ActionButtonName")]
    public string ActionButtonName { get; set; }
    
    [BsonElement("ActionButtonProperties")]
    public ActionButtonProperty ActionButtonProperties { get; set; }
}

public class ActionButtonProperty
{
    
    [BsonElement("FontColor")]
    public string FontColor { get; set; }
    
    [BsonElement("BackgroundColor")]
    public string BackgroundColor { get; set; }
}

public class Section
{
    [BsonElement("SectionId")]
    public string SectionId { get; set; } 
    
    [BsonElement("SectionName")]
    public string SectionName { get; set; } 
    
    [BsonElement("SectionIndex")]
    public long SectionIndex { get; set; }

    [BsonElement("SectionProperties")]
    public SectionProperty SectionProperties { get; set; } 
    
    [BsonElement("Components")] 
    public List<Component> Components { get; set; }
}

public class SectionProperty
{
    [BsonElement("SectionFontName")] 
    public string SectionFontName { get; set; } 

    [BsonElement("SectionFontSize")] 
    public string SectionFontSize { get; set; } 
        
    [BsonElement("SectionFontColor")]
    public string SectionFontColor { get; set; }

    [BsonElement("SectionBackgroundColor")]
    public string SectionBackgroundColor { get; set; }
}

public class Component
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("ComponentIndex")] 
    public long ComponentIndex { get; set; } 
    
    [BsonElement("ComponentLabel")] 
    public string ComponentLabel { get; set; } 
    
    [BsonElement("ComponentType")] 
    public string ComponentType { get; set; }

    [BsonElement("ComponentProperties")] 
    public ComponentProperty ComponentProperties { get; set; } 
    
    [BsonElement("ComponentTemplate")] 
    public bool ComponentTemplate { get; set; } 
}

public class ComponentProperty
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
    public string HeadingFontSize { get; set; } 
    
    [BsonElement("SubheadingFontSize")]
    public string SubheadingFontSize { get; set; }

    [BsonElement("Validation")]
    public Validations Validation { get; set; }
}

public class Validations
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
