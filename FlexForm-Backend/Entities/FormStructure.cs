using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Entities;

[BsonIgnoreExtraElements]
public class FormStructure
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    [BsonElement("formId")] 
    public string FormId { get; set; }
    
    [BsonElement("ticketId")] 
    public string TicketId { get; set; }
    
    [BsonElement("formName")] 
    public string FormName { get; set; }
    
    [BsonElement("formDescriptions")] 
    public string FormDescriptions { get; set; }
    
    [BsonElement("formCreateTimestamp")] 
    public DateTime FormCreateTimestamp { get; set; }
    
    [BsonElement("formModifiedTimestamp")] 
    public DateTime FormModifiedTimestamp { get; set; }
    
    [BsonElement("createdByUser")] 
    public string CreatedByUser { get; set; }
    
    [BsonElement("modifiedByUser")] 
    public string ModifiedByUser { get; set; }
    
    [BsonElement("useTemplate")] 
    public bool UseTemplate { get; set; }
    
    [BsonElement("actionButton")] 
    public ActionButtons ActionButton { get; set; } 
    
    [BsonElement("sections")] 
    public List<Section> Sections { get; set; }
}

public class ActionButtons
{
    [BsonElement("actionButtonName")]
    public string ActionButtonName { get; set; }
    
    [BsonElement("actionButtonProperties")]
    public ActionButtonProperty ActionButtonProperties { get; set; }
}

public class ActionButtonProperty
{
    
    [BsonElement("fontColor")]
    public string FontColor { get; set; }
    
    [BsonElement("backgroundColor")]
    public string BackgroundColor { get; set; }
}

public class Section
{
    [BsonElement("sectionId")]
    public string SectionId { get; set; } 
    
    [BsonElement("sectionName")]
    public string SectionName { get; set; } 
    
    [BsonElement("sectionIndex")]
    public long SectionIndex { get; set; }

    [BsonElement("sectionProperties")]
    public SectionProperty SectionProperties { get; set; } 
    
    [BsonElement("components")] 
    public List<Component> Components { get; set; }
}

public class SectionProperty
{
    [BsonElement("fontName")] 
    public string FontName { get; set; } 

    [BsonElement("fontSize")] 
    public string FontSize { get; set; } 
        
    [BsonElement("fontColor")]
    public string FontColor { get; set; }

    [BsonElement("backgroundColor")]
    public string BackgroundColor { get; set; }
}

public class Component
{
    [BsonElement("componentId")] 
    public string ComponentId { get; set; } 
    
    [BsonElement("componentIndex")] 
    public long ComponentIndex { get; set; } 
    
    [BsonElement("componentLabel")] 
    public string ComponentLabel { get; set; } 
    
    [BsonElement("componentType")] 
    public string ComponentType { get; set; }

    [BsonElement("componentProperties")] 
    public ComponentProperty ComponentProperties { get; set; } 
    
    [BsonElement("componentTemplate")] 
    public bool ComponentTemplate { get; set; } 
}

public class ComponentProperty
{
    [BsonElement("headingText")]
    public string HeadingText { get; set; }
    
    [BsonElement("subheadingText")]
    public string SubheadingText { get; set; }
    
    [BsonElement("alignment")]
    public string Alignment { get; set; }
    
    [BsonElement("headingFontColor")]
    public string HeadingFontColor { get; set; } 
    
    [BsonElement("subheadingFontColor")]
    public string SubheadingFontColor { get; set; } 
    
    [BsonElement("headingFontSize")]
    public string HeadingFontSize { get; set; } 
    
    [BsonElement("subheadingFontSize")]
    public string SubheadingFontSize { get; set; }

    [BsonElement("validation")]
    public Validations Validation { get; set; }
}

public class Validations
{
    [BsonElement("day")]
    public string Day { get; set; }
    
    [BsonElement("gender")]
    public string Gender { get; set; }
        
    [BsonElement("month")]
    public string Month { get; set; }
    
    [BsonElement("priority")]
     public string Priority { get; set; }
            
    [BsonElement("status")]
     public string Status { get; set; }
}

