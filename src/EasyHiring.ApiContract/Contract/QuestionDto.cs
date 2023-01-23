namespace EasyHiring.ApiContract.Contract;

public class QuestionDto
{
    public string Text { get; set; }
    public List<OptionDto> Options { get; set; }
}