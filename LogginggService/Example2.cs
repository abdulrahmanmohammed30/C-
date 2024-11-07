using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exmaple2
{
    public class ReportGenerator
    {
        private IReportGenerator _ReportGenerator;
        public ReportGenerator(IReportGenerator ReportGenerator)
        {
            _ReportGenerator = ReportGenerator;
        }
        public string GenerateReport(string data)
        {
            return _ReportGenerator.GenerateReport(data);
        }
    }
    public interface IReportGenerator
    {
        public string GenerateReport(string data);
    }
    public class PDFReportGenerator : IReportGenerator
    {

        public string GenerateReport(string data)
        {
            // Logic to generate PDF report
            return "PDF Report";
        }

    }

    public class CSVReportGenerator : IReportGenerator
    {
        public string GenerateReport(string data)
        {
            // Logic to generate CSV report
            return "CSV Report";
        }
    }
}