
using P01_StudentSystem.Common;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    public int ResourceId { get; set; }

    [MaxLength(LengthRestrictions.MaxNameLength)]
    public string Name { get; set; }
    public string Url { get; set; }

    [MaxLength(LengthRestrictions.MaxEnumLength)]
    public string ResourceType { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; }
}
