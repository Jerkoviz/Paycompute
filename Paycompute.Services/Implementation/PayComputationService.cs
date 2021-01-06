using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Paycompute.Services.Implementation
{
    public class PayComputationService : IPayComputationService
    {
        private decimal contractualEarnings;
        private decimal overtimeHours;
        private readonly ApplicationDbContext _context;

        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;

        }
        public decimal ContractualEarnings(decimal hoursWorked, decimal contractualHours, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            contractualEarnings = contractualHours * hourlyRate;
            return contractualEarnings;
        }            

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords;        

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
            {
                Text = taxYears.YearOfTax,
                Value = taxYears.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int paymentRecordId) =>     
            _context.PaymentRecords.Where(pay => pay.Id == paymentRecordId).FirstOrDefault();


        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
            => totalEarnings - totalDeduction;      

        public decimal OverTimeEarnings(decimal overTimeHours, decimal overTimeRate) 
            => overTimeHours * overTimeRate;

        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if ( hoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            overtimeHours = hoursWorked - contractualHours;
            return overtimeHours;
        }

        public decimal OverTimeRate(decimal hourlyRate)
            => hourlyRate * 1.5m;

        public decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFees)
                => tax + nic + studentLoanRepayment + unionFees;

        public decimal TotalEarnings(decimal overTimeEarnings, decimal contractualEarnings)
            => contractualEarnings + overTimeEarnings;
    }
}
