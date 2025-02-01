namespace DigraphyApi.Dto;

public class TodoDto : CreateTodoDto
{
    public int Id { get; set; }
}

public class CreateTodoDto
{
    public string Name { get; set; }
}
