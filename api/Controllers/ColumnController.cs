using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("columns")]
public class ColumnController : ControllerBase
{

    private readonly DataBaseContext _dbContext;

    public ColumnController(DataBaseContext dbContext)
    {
        _dbContext= dbContext;
    }

    [HttpPost]
    public async Task<ActionResult<Column>> PostCard(ColumnDTO column)
    {
        Column columnNew = new();
        columnNew.Name = column.Name;
        _dbContext.Columns.Add(columnNew);
        await _dbContext.SaveChangesAsync();
        return Ok(column);
    }
}
