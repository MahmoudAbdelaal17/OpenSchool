using OpenSchool.Web.Api.Brokers.Loggings;
using OpenSchool.Web.Api.Brokers.Storages;
using OpenSchool.Web.Api.Models.Students;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSchool.Web.Api.Services.Foundations.Students
{
    public partial class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggerBroker;

        public StudentService(IStorageBroker storageBroker,ILoggingBroker loggerBroker)
        {
            this.storageBroker = storageBroker;
            this.loggerBroker = loggerBroker;
        }
        public ValueTask<Student> RegisterStudentAsync(Student student) => 
        TryCatch(async () =>
            {
                ValidateStudentOnCreate(student);

                return await this.storageBroker.InsertStudentAsync(student);
            });        
    }
}
