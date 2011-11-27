using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Activities.DurableInstancing;
using System.Runtime.DurableInstancing;
using System.Activities;

namespace YunShanOA.Workflow.DocumentWF
{
    public class DocumentWorkFlowProcess
    {
        static AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
        public static Guid CreateAndRun(requestinfo requsetForm)
        {
            //工作流服务实例的状态信息持久保存到数据库中
            //SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore("server=.;database=aspnetdb;uid=sa;pwd=0000");
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(@"Data Source=.\SQLEXPRESS;Initial Catalog=aspnetdb;Integrated Security=True");//在宿主程序中首先我们创建SqlWorkflowInstanceStore的实例
            InstanceView view = instanceStore.Execute(instanceStore.CreateInstanceHandle(), new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));

            instanceStore.DefaultInstanceOwner = view.InstanceOwner;//对SqlWorkflowInstanceStore实例的各种配置

            IDictionary<string, object> input = new Dictionary<string, object> 
            {
                { "Request" , requsetForm }
            };

            WorkflowApplication application = new WorkflowApplication(new DocumentPublish(), input);

            application.InstanceStore = instanceStore;//并将application的InstanceStore属性设置为该实例来指定使用的持久化存储
            application.PersistableIdle = (e) =>//获取工作流实例处于空闲状态并且可被保留时调用
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;//保持并且卸载工作流
            };
            application.Unloaded = (e) =>//获取或设置卸载当前工作流时调用
            {
                instanceUnloaded.Set();//将事件设置为主终止状态允许其他的线程继续。
            };
            application.OnUnhandledException = (ex) =>//异常
            {
                Console.Write("Exception");
                return UnhandledExceptionAction.Terminate;
            };

            Guid id = application.Id;
            //application.Persist();
            application.Run();
            instanceUnloaded.WaitOne();//阻止当前线程，直到收到信号
            return id;
        }
        // executed when instance is persisted持续
        public static void OnWorkflowCompleted(WorkflowApplicationCompletedEventArgs e)
        {
        }
        // executed when instance goes idle
        public static void OnIdle(WorkflowApplicationIdleEventArgs e)
        {
        }
        public static PersistableIdleAction OnIdleAndPersistable(WorkflowApplicationIdleEventArgs e)
        {
            return PersistableIdleAction.Persist;// 保持工作流
        }
        public static void RunReviewQicao(Guid id, ReviewQicao Form)
        {
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(@"server=.\SQLEXPRESS;database=aspnetdb;uid=sa;pwd=123456");
            WorkflowApplication application2 = new WorkflowApplication(new DocumentPublish());
            application2.InstanceStore = instanceStore;
            application2.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine("\nWorkflowApplication has Completed in the {0} state.", workflowApplicationCompletedEventArgs.CompletionState);
                instanceUnloaded.Set();
            };
            application2.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };
            application2.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };
            application2.Load(id);
            application2.ResumeBookmark("WaitReviewQicao", Form);
            instanceUnloaded.WaitOne();
            Console.ReadLine();
        }
        public static void RunChecking(Guid id, ReviewCheck Form)
        {
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(@"server=.\SQLEXPRESS;database=aspnetdb;uid=sa;pwd=123456");
            WorkflowApplication application2 = new WorkflowApplication(new DocumentPublish());
            application2.InstanceStore = instanceStore;
            application2.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine("\nWorkflowApplication has Completed in the {0} state.", workflowApplicationCompletedEventArgs.CompletionState);
                instanceUnloaded.Set();
            };
            application2.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };
            application2.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };
            application2.Load(id);
            application2.ResumeBookmark("WaitChecking", Form);
            instanceUnloaded.WaitOne();
            Console.ReadLine();
        }
        public static void RunCheckCheck(Guid id, ReviewCheckCheck Form)
        {
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(@"server=.\SQLEXPRESS;database=aspnetdb;uid=sa;pwd=123456");
            WorkflowApplication application2 = new WorkflowApplication(new DocumentPublish());
            application2.InstanceStore = instanceStore;
            application2.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine("\nWorkflowApplication has Completed in the {0} state.", workflowApplicationCompletedEventArgs.CompletionState);
                instanceUnloaded.Set();
            };
            application2.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };
            application2.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };
            application2.Load(id);
            application2.ResumeBookmark("WaitCheckingChecking", Form);
            instanceUnloaded.WaitOne();
            Console.ReadLine();
        }
    }
}
