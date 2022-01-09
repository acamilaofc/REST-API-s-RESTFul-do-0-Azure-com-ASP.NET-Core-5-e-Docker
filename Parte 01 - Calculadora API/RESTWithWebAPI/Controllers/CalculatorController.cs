using Microsoft.AspNetCore.Mvc;

namespace RESTWithWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
  private readonly ILogger<CalculatorController> _logger;

  public CalculatorController(ILogger<CalculatorController> logger)
  {
    _logger = logger;
  }

  [HttpGet("addition/{fstN}/{sndN}")]
  public IActionResult addition(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((ToDecimal(fstN) + ToDecimal(sndN)).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("subtraction/{fstN}/{sndN}")]
  public IActionResult Subtraction(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((ToDecimal(fstN) - ToDecimal(sndN)).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("multiplication/{fstN}/{sndN}")]
  public IActionResult Multiplication(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((ToDecimal(fstN) * ToDecimal(sndN)).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("division/{fstN}/{sndN}")]
  public IActionResult Division(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((ToDecimal(fstN) / ToDecimal(sndN)).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("modulus/{fstN}/{sndN}")]
  public IActionResult Modulus(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((ToDecimal(fstN) % ToDecimal(sndN)).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("sqrt/{fstN}")]
  public IActionResult Squareroot(string fstN)
  {
    if (IsNumeric(fstN))
      return Ok((Math.Sqrt((double)ToDecimal(fstN))).ToString());
    return BadRequest("Invalid Input");
  }
  [HttpGet("pow/{fstN}/{sndN}")]
  public IActionResult Power(string fstN, string sndN)
  {
    if (IsNumeric(fstN) && IsNumeric(sndN))
      return Ok((Math.Pow((double)ToDecimal(fstN), (double)ToDecimal(sndN))).ToString());
    return BadRequest("Invalid Input");
  }


  private bool IsNumeric(string strNum)
  {
    bool isNumber = double.TryParse(strNum, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out double converted);
    return isNumber;
  }
  private decimal ToDecimal(string strNum)
  {
    if (decimal.TryParse(strNum, out decimal converted))
      return converted;
    return 0;
  }
}


