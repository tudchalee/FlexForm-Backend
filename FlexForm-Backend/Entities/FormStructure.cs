using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlexForm_Backend.Entities;

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
    public int SectionFontSize { get; set; } 
        
    [BsonElement("SectionFontColor")]
    public string SectionFontColor { get; set; }

    [BsonElement("SectionBackgroundColor")]
    public string SectionBackgroundColor { get; set; }
}

public class Component
{
    [BsonElement("ComponentId")] 
    public string ComponentId { get; set; }

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
    public int HeadingFontSize { get; set; } 
    
    [BsonElement("SubheadingFontSize")]
    public int SubheadingFontSize { get; set; }

    [BsonElement("Validation")]
    public string Validation { get; set; }
    
    [BsonElement("LabelText")]
    public string LabelText { get; set; }
    
    [BsonElement("SubLabelText")]
    public string SubLabelText { get; set; }
    
    [BsonElement("Required")]
    public bool Required { get; set; }
    
    [BsonElement("Placeholder")]
    public string Placeholder { get; set; }
    
    [BsonElement("FixWidth")]
    public bool FixWidth { get; set; }
    
    [BsonElement("Width")]
    public int Width { get; set; }
    
    [BsonElement("ReadOnly")]
    public bool ReadOnly { get; set; }
    
    [BsonElement("CharacterLimit")]
    public bool CharacterLimit { get; set; }
    
    [BsonElement("CharacterLimitValue")]
    public int CharacterLimitValue { get; set; }
    
    [BsonElement("FontColor")]
    public string FontColor { get; set; }
    
    [BsonElement("InputBgColor")]
    public string InputBgColor { get; set; }
    
    [BsonElement("BorderColor")]
    public string BorderColor { get; set; }
    
    [BsonElement("LabelFontSize")]
    public int LabelFontSize { get; set; }
    
    [BsonElement("PredefinedOptions")]
    public string PredefinedOptions { get; set; }
    
    [BsonElement("Options")]
    public List<string> Options { get; set; }
    
    [BsonElement("MultipleChoice")]
    public bool MultipleChoice { get; set; }
    
    [BsonElement("SpreadToColumns")]
    public bool SpreadToColumns { get; set; }
}

