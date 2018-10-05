using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VendorManager
{
    public class LogManager
    {
        private string _connectionString = @"Data Source=CLODEV01SSQL01.cloudvirga.local\TRUNK126;Initial Catalog=EventLog;Integrated Security=true;Application Name=TRUNK115Services";
        private string _connectionStringServcies = @"Data Source=CLODEV01SSQL01.cloudvirga.local\TRUNK126;Initial Catalog=Services;Integrated Security=true;Application Name=TRUNK115Services";


        public void SetConnection(string input)
        {
            var serverAddress = string.Join(",", input.Split(',').Skip(1));
            _connectionString = Regex.Replace(_connectionString, @"^Data Source=(.*?);(.*)$", $"Data Source={serverAddress};$2");
            _connectionStringServcies = Regex.Replace(_connectionStringServcies, @"^Data Source=(.*?);(.*)$", $"Data Source={serverAddress};$2");
        }

        public DateTime GetLoanCreationDateTime(Guid loanId)
        {


                var loan =  GetLoan(loanId);
                if (loan != null)
                    return loan.OpenDate;
            

            return new DateTime(1900,1,1);
        }

        public List<LogData> GetLogData(Guid loanId, int minId)
        {
            Guid temp;
            var output = new List<LogData>();
            var zeroLoanId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            using (var dc = new VendorDataContext(_connectionString))
            {

                var loanIdLogs = dc.LogDatas.Where(x => x.LoanId == loanId && x.Id > minId && !x.Message.StartsWith("Borrower ID in VM.PropertyViewModel was unexpectedly changed")).ToList();
                if (!loanIdLogs.Any()) return new List<LogData>();
                var minTime = loanIdLogs.Min(x => x.DatabaseTime);
                var maxTime = loanIdLogs.Max(x => x.DatabaseTime);
                var minnId = loanIdLogs.Min(x => x.Id);
                var maxxId = loanIdLogs.Max(x => x.Id);
                var minimumLogId = minId;

                if (loanIdLogs.Any())
                {
                    loanIdLogs.ForEach(x=> x.EventTime = x.EventTime.Value.ToLocalTime());
                    minimumLogId = loanIdLogs.Min(x => x.Id);
                    if (minId > 0 && minId > minimumLogId)
                        minimumLogId = minId;
                }
                var correlationIdLogs = dc.LogDatas.Where(x => x.Id >= minimumLogId && x.LoanId != loanId &&  loanIdLogs.Where(y=> y.CorrelationId != "{00000000-0000-0000-0000-000000000000}").Select(p => p.CorrelationId).Distinct().Contains(x.CorrelationId)).ToList();
                var trackingIdLogs = dc.LogDatas.Where(x => x.Id >= minimumLogId && x.LoanId != loanId && loanIdLogs.Where(y => y.CorrelationId != "{00000000-0000-0000-0000-000000000000}").Select(p => p.TrackingId).Distinct().Contains(x.TrackingId)).ToList() ;


                var timeRangeOtherLogs = dc.LogDatas.Where(p=> p.EventType.ToLower() == "error" && p.Id>= minnId && p.Id <= maxxId &&  p.LoanId == zeroLoanId && p.TrackingId == zeroLoanId && p.DatabaseTime >= minTime && p.DatabaseTime <= maxTime && p.CorrelationId == "{00000000-0000-0000-0000-000000000000}").Take(200).ToList();

                var someMore = true;
                int i = 0;
                while (someMore)
                {
                    var sameTime = dc.LogDatas.Where(p => p.EventType.ToLower() == "error" && p.Id >= minnId && p.Id <= maxxId && p.LoanId == zeroLoanId && p.TrackingId == zeroLoanId && p.DatabaseTime >= minTime && p.DatabaseTime <= maxTime && p.CorrelationId == "{00000000-0000-0000-0000-000000000000}").Skip(i * 200).Take(200).ToList();
                    i++;
                    if (!sameTime.Any() || i>= 10) someMore = false;
                    timeRangeOtherLogs.AddRange(sameTime);
                }


                timeRangeOtherLogs = timeRangeOtherLogs.OrderByDescending(x => x.Id).ToList();
                output.AddRange(loanIdLogs);
                output.AddRange(correlationIdLogs);
                output.AddRange(trackingIdLogs);
                foreach (var threadIdLog in timeRangeOtherLogs)
                {
                    threadIdLog.EventType = "Prob" + threadIdLog.EventType;
                }
                output.AddRange(timeRangeOtherLogs);

            }

            
            return output;
        }

        public Guid GetLoanId(string loanId)
        {
            var zeroLoanId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            using (var dc = new VendorDataContext(_connectionStringServcies))
            {
                Guid lid;
                if (Guid.TryParse(loanId, out lid))
                    return lid;
                var loan = dc.Loans.FirstOrDefault(x => x.LoanNumber == loanId);
                if (loan != null) return loan.LoanId;
            }

            return zeroLoanId;

        }

        public Loan GetLoan(Guid loanId)
        {
            using (var dc = new VendorDataContext(_connectionStringServcies))
            {
                return  dc.Loans.FirstOrDefault(x => x.LoanId == loanId);
            }

        }

        public List<AuditLog> GetAuditLog(Guid loanId)
        {
            var dc = new VendorDataContext(_connectionStringServcies);
            {
                return dc.AuditLogs.Where(x => x.LoanId == loanId).ToList();
            }
        }

        public List<IntegrationStatusDetail> GetIntegrationLog(Guid loanId)
        {
            var dc = new VendorDataContext(_connectionStringServcies);
            {
                var integrationStatuses = dc.IntegrationStatus.Where(x => x.LoanId == loanId).ToList();
                
                var details = dc.IntegrationStatusDetails.Where(x =>  integrationStatuses.Select(p=> p.IntegrationStatusID).Contains(x.IntegrationStatusID )).ToList();
                details.ForEach(x=> x.Message = x.Message.Replace("<", Environment.NewLine +  "<"));
                return details;
            }

        }

        public void ExecuteSQL(string sqlString)
        {
            var dc = new VendorDataContext(_connectionStringServcies);
            {
                dc.ExecuteCommand(sqlString);
            }

        }
    }
}
