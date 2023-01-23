namespace EasyHiring.Domain.Entities;

public class Question : Entity
{
    public string Text { get; set; }
    public List<Option> Options { get; set; }
}