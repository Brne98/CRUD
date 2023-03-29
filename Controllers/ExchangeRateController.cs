using ExchangeRate.Api.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExchangeRateController : ControllerBase
{
    private readonly DataContext _context;
    
    public ExchangeRateController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExchangeRate>>> GetExchangeRate()
    {
        var exchangeRates = await _context.ExchangeRates.ToListAsync();

        return Ok(exchangeRates);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExchangeRate>> GetExchangeRateById(int id)
    {
        var exchangeRate = await _context.ExchangeRates.FindAsync(id);

        if (exchangeRate is null)
            return BadRequest($"Kursna lista za id {id} ne postoji");

        return Ok(exchangeRate);
    }

    [HttpPost]
    public async Task<ActionResult<List<ExchangeRate>>> AddExchangeRate(ExchangeRate exchangeRate)
    {
        _context.ExchangeRates.Add(exchangeRate);
        await _context.SaveChangesAsync();
        
        return Ok(exchangeRate);
    }

    [HttpPut]
    public async Task<ActionResult<ExchangeRate>> UpdateExchangeRate(ExchangeRate request)
    {
        var exchangeRate = await _context.ExchangeRates.FindAsync(request.Id);

        if (exchangeRate is null)
            return BadRequest($"Kursna lista za id {request.Id} ne postoji");

        exchangeRate.Currency = request.Currency;
        exchangeRate.Buy = request.Buy;
        exchangeRate.Middle = request.Middle;
        exchangeRate.Sell = request.Sell;

        await _context.SaveChangesAsync();
        
        return Ok(exchangeRate);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<ExchangeRate>> DeleteExchangeRate(int id)
    {
        var exchangeRate = await _context.ExchangeRates.FindAsync(id);

        if (exchangeRate is null)
            return BadRequest($"Kursna lista za id {id} ne postoji");

        _context.ExchangeRates.Remove(exchangeRate);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}