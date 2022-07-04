using Personal.Tasket.Client.Models;

public class TasketState
{
    public TisketModel Tisket { get; private set; } = new();
    public static List<TisketModel> Tasket { get; private set; } = new();

    private ILogger<TasketState> _logger;

	public TasketState(ILogger<TasketState> logger)
	{
		_logger = logger;
	}

    public async Task AddFormTisket(TisketModel tisketForm)
    {
        Tisket = new()
        {
            Id = Tasket.Count == 0 ? 1: Tasket.Last().Id + 1,
            Title = tisketForm.Title,
            Description = tisketForm.Description
        };
        Tasket.Add(Tisket);
        await Task.FromResult(Tasket.Exists(t => t.Id == Tisket.Id));
        _logger.LogInformation($"Tisket {Tisket.Id}, {Tisket.Title}, added {Tisket.WhenAdded.ToString()}");
    }

    public async Task CompleteTisket(TisketModel completedTisket)
    {
        completedTisket.IsCompleted = true;
        completedTisket.WhenCompleted = DateTime.Now.ToLocalTime();
        var completed = Tasket.Find(t => t.Id == completedTisket.Id);
        if (completed != null)
        {
            await Task.FromResult(completed = completedTisket);
        }
    }
    
    public async Task DeleteTisket(TisketModel selectedTisket)
    {
        await Task.FromResult(Tasket.Remove(selectedTisket));
    }

    public void ResetTisket()
    {
        Tisket = new();
        
    }

    public void EmptyTasket()
    {
        Tasket.Clear();
    }

    public void LoadDummyData(int dataAmount)
    {
        for (int i = 0; i < dataAmount; i++)
        {
            var id = Tasket.Count == 0 ? 1 : Tasket.Last().Id + 1;

            Tasket.Add(new() 
            { 
                Id = id, 
                Title = $"Title {id}", 
                Description = $"Description {id}" 
            });
        }
    }
}
