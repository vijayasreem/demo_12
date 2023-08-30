
using Microsoft.AspNetCore.Mvc;
using sacral.DTO;
using sacral.Service;
using System;
using System.IO;
using System.Threading.Tasks;

namespace sacral.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class MortgageLoanController : ControllerBase
    {
        private readonly IUserStoryService _userStoryService;

        public MortgageLoanController(IUserStoryService userStoryService)
        {
            _userStoryService = userStoryService;
        }

        [HttpPost]
        [Route("Apply")]
        public async Task<IActionResult> ApplyForMortgageLoan([FromBody] MortgageLoanApplicationDTO application)
        {
            try
            {
                // Validate file format
                if (application.FileFormat != "PDF" && application.FileFormat != "JPEG")
                {
                    throw new InvalidFileException("Invalid file format. Only PDF and JPEG are supported.");
                }

                // Evaluate credit score and income
                var creditScore = await EvaluateCreditScoreAsync(application.CustomerId);
                var income = await GetCustomerIncomeAsync(application.CustomerId);

                // Check age requirement
                if (!CheckAgeRequirement(application.CustomerId))
                {
                    return BadRequest("Applicants under 18 or over 65 years of age are not eligible.");
                }

                // Check credit score requirement
                if (creditScore < 600)
                {
                    return BadRequest("Applicants with a credit score below 600 are not eligible.");
                }

                // Approve or reject application based on credit score
                if (creditScore > 700)
                {
                    return Ok("Application approved.");
                }
                else
                {
                    return BadRequest("Application rejected.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private async Task<int> EvaluateCreditScoreAsync(int customerId)
        {
            // Implementation to evaluate credit score
            // ...

            return await Task.FromResult(0);
        }

        private async Task<decimal> GetCustomerIncomeAsync(int customerId)
        {
            // Implementation to get customer income
            // ...

            return await Task.FromResult(0m);
        }

        private bool CheckAgeRequirement(int customerId)
        {
            // Implementation to check age requirement
            // ...

            return true;
        }
    }
}
