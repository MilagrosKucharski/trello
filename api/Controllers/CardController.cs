using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("cards")]
public class CardController : ControllerBase
{
    private readonly DataBaseContext _dbContext;

    public CardController(DataBaseContext dbContext)
    {
        _dbContext= dbContext;
    }

    [HttpPost("{columnId}")]
    public async Task<ActionResult<Card>> PostCard(CardNewDTO cardNew, int columnId)
    {
        Column column = _dbContext.Columns.FirstOrDefault(c => c.Id == columnId);
        Card card = new();
        card.Description = cardNew.Description;
        card.ColumnId = columnId; 
        column.Cards.Add(card);
        _dbContext.Cards.Add(card);
        await _dbContext.SaveChangesAsync();
        return Ok(card);
    }
    [HttpPut("{columnId}")]
    public async Task<ActionResult<Card>> MoveCard(Card card, int newColumnId)
    {
        Column column = _dbContext.Columns.FirstOrDefault(c => c.Id == newColumnId);
        card.ColumnId = newColumnId; 
        column.Cards.Add(card);
        _dbContext.Cards.Add(card);
        await _dbContext.SaveChangesAsync();
        return Ok(card);
    }
}
