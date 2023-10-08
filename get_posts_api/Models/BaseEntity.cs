using System.ComponentModel.DataAnnotations.Schema;

public class BaseEntity
{
    [NotMapped]
    public int Id {get;set;}
    public Guid UIId {get;set;}
}