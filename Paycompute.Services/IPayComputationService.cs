using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paycompute.Services
{
    public interface IPayComputationService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OverTimeHours(decimal hoursWorked, decimal contractualHours);
        decimal OverTimeRate(decimal hourlyRate);
        decimal ContractualEarnings(decimal hoursWorked, decimal contractualHours, decimal hourlyRate);
        decimal OverTimeEarnings(decimal overTimeHours, decimal overTimeRate);
        decimal TotalEarnings(decimal hoursWorked, decimal contractualEarnings);
        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees);
        decimal NetPay(decimal totalEarnings, decimal totalDeduction);

    }
}
