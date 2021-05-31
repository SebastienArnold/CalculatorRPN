using CalculatorRPN.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CalculatorRPN.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public ActionResult<List<double>> GetStack()
        {
            try
            {
                var stack = _calculatorService.GetStack();
                return Ok(stack);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error retrieving the stack", exception);
                return StatusCode(500, "An unknown error occurred.");
            }
        }

        [HttpPost]
        [Route("{value}")]
        public ActionResult AddValueToStack(double value)
        {
            try
            {
                _calculatorService.AddValue(value);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error adding value to the stack (value:{value})", exception);
                return StatusCode(500, "An unknown error occurred.");
            }
        }

        private ActionResult ExecuteOperator(Action calculatorServiceOperation)
        {
            try
            {
                calculatorServiceOperation.Invoke();
                return Ok();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return StatusCode(500, invalidOperationException.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError("Error applying a sum", exception);
                return StatusCode(500, "An unknown error occurred.");
            }
        }

        [HttpPost]
        [Route("sum")]
        public ActionResult Sum()
        {
            return ExecuteOperator(() => _calculatorService.Sum());
        }

        [HttpPost]
        [Route("sustract")]
        public ActionResult Substract()
        {
            return ExecuteOperator(() => _calculatorService.Substract());
        }

        [HttpPost]
        [Route("multiply")]
        public ActionResult Multiply()
        {
            return ExecuteOperator(() => _calculatorService.Multiply());
        }

        [HttpPost]
        [Route("divide")]
        public ActionResult Divide()
        {
            return ExecuteOperator(() => _calculatorService.Divide());
        }

        [HttpDelete]
        public ActionResult ClearStack()
        {
            try
            {
                _calculatorService.Clear();
                return Ok();
            }
            catch(Exception exception)
            {
                _logger.LogError("Error clearing the stack", exception);
                return StatusCode(500, "An unknown error occurred.");
            }
        }
    }
}
