﻿using OtripleS.Web.Api.Brokers.Loggings;
using OtripleS.Web.Api.Brokers.Storage;
using OtripleS.Web.Api.Models.Students;
using System;
using System.Threading.Tasks;

namespace OtripleS.Web.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public StudentService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Student> DeleteStudentAsync(Guid studentId) 
        {
            Student maybeStudent =
                await this.storageBroker.SelectStudentByIdAsync(studentId);

            return await this.storageBroker.DeleteStudentAsync(maybeStudent);
        }
    }
}