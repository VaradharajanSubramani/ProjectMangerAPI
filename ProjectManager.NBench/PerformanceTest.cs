using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using ProjectManager.Repository;

namespace ProjectManager.NBench
{
    public class PerformanceTest
    {
        TasksRepositry taskRepo = new TasksRepositry();
        ProjectRepository prjRepo = new ProjectRepository();
        UserRepositry usrRepo = new UserRepositry();

        [PerfBenchmark(NumberOfIterations = 1,
           RunMode = RunMode.Throughput,
           TestMode = TestMode.Test,
           SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 100)]

        public void GetTasks_performance()
        {
            ////Console.WriteLine("started");
            taskRepo.GetAllTasks();
           // Console.WriteLine("End");
        }

        [PerfBenchmark(NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Test,
          SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 100)]
        public void GetUsers_performance()
        {
           // Console.WriteLine("started");
            usrRepo.GetAllUsers();
           // Console.WriteLine("End");
        }

        [PerfBenchmark(NumberOfIterations = 1,
          RunMode = RunMode.Throughput,
          TestMode = TestMode.Test,
          SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 2000)]

        public void GetProjs_performance()
        {
            //Console.WriteLine("started");
            prjRepo.GetAllProjects();
           // Console.WriteLine("End");
        }
    }
}
