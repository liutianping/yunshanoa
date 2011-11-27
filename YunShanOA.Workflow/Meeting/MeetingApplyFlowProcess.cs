using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Activities.DurableInstancing;
using System.Activities;
using System.Runtime.DurableInstancing;
using System.Configuration;

namespace YunShanOA.Workflow.Meeting
{
    public class MeetingApplyFlowProcess
    {
        static AutoResetEvent instanceUnloaded = new AutoResetEvent(false);
        static readonly string connectionString = ConfigurationManager.AppSettings["connectionstring"];
        static Hashtable InstanceHashtable = new Hashtable();

        /// <summary>
        /// 重新启动工作流，是审核过程中保存审核结果的必要流程
        /// </summary>
        /// <param name="meeting">传入一个Meeting对象，主要是取里面的InstanceID和改变Status</param>
        public static void RunInstance(Model.Meeting meeting)
        {

            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(connectionString);
            IDictionary<string, object> input = new Dictionary<string, object>() 
            { 
                 { "Request", meeting } 
            };

            WorkflowApplication application1 = new WorkflowApplication(new MeetingApply());
            application1.InstanceStore = instanceStore;

            application1.Completed = (workflowComplete) =>
            {

            };

            application1.Unloaded = (workflowUnloaded) =>
            {
                instanceUnloaded.Set();
            };
            application1.PersistableIdle = (e) =>
                        {
                            instanceUnloaded.Set();
                            return PersistableIdleAction.Unload;
                        };
            application1.Load(meeting.WFID);

            application1.ResumeBookmark("MeetingApply", meeting.MeetingStatus);
            
            //instanceUnloaded.WaitOne();
        }

        /// <summary>
        /// 创建并启动一个工作流，在申请时候触发
        /// </summary>
        /// <param name="meeting">申请时所填表单的数据</param>
        /// <returns>返回一个Guid</returns>
        public static Guid CreateAndRun(Model.Meeting meeting, Dictionary<int, int> d_EquipmentCount,Dictionary<string,string> MeetingUserNameAndEmail,Model.MeetingRoom MeetingRoomIDAndName)
        {
            
            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(connectionString);
            InstanceView view = instanceStore.Execute(instanceStore.CreateInstanceHandle(), new CreateWorkflowOwnerCommand(),TimeSpan.FromDays(30));

            instanceStore.DefaultInstanceOwner = view.InstanceOwner;

            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("Request",meeting);
            input.Add("EquipmentCount",d_EquipmentCount);
            input.Add("MeetingUserEmailFrom", MeetingUserNameAndEmail);
            input.Add("MeetingRoomIDAndName", MeetingRoomIDAndName);
            WorkflowApplication application = new WorkflowApplication(new MeetingApply(),input);

            application.InstanceStore = instanceStore;
            application.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };

            application.Unloaded = (e) =>
            {
                instanceUnloaded.Set();
            };

            application.OnUnhandledException = (ex) =>
            {
                return UnhandledExceptionAction.Terminate;
            };

            Guid id = application.Id;
            application.Persist();
            application.Run();
            instanceUnloaded.WaitOne();
            return id;
        }



        /// <summary>
        /// 重新启动工作流，是审核过程中保存审核结果的必要流程
        /// </summary>
        /// <param name="meeting">传入一个Meeting对象，主要是取里面的InstanceID和改变后的Status(这个status是标识meetingAndRoom的)</param>
        public static void ProcessEquipmentArr(Model.Meeting meeting)
        {

            //SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(connectionString);

            //WorkflowApplication application1 = new WorkflowApplication(new MeetingApply());
            //application1.InstanceStore = instanceStore;
           
            //application1.Completed = (workflowComplete) =>
            //{

            //};

            //application1.Unloaded = (workflowUnloaded) =>
            //{
            //    instanceUnloaded.Set();
            //};
            //application1.PersistableIdle = (e) =>
            //           {
            //               instanceUnloaded.Set();
            //               return PersistableIdleAction.Unload;
            //           };
            //application1.Load(meeting.WFID);

            //application1.ResumeBookmark("MeetingApply", meeting.MeetingStatus);
           
            //instanceUnloaded.WaitOne();


            SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(connectionString);
            IDictionary<string, object> input = new Dictionary<string, object>() 
            { 
                 { "Request", meeting } 
            };

            WorkflowApplication application1 = new WorkflowApplication(new MeetingApply());
            application1.InstanceStore = instanceStore;

            application1.Completed = (workflowComplete) =>
            {

            };

            application1.Unloaded = (workflowUnloaded) =>
            {
                instanceUnloaded.Set();
            };
            application1.PersistableIdle = (e) =>
                       {
                           instanceUnloaded.Set();
                           return PersistableIdleAction.Unload;
                       };
            application1.Load(meeting.WFID);

            application1.ResumeBookmark("ArrEquipment", meeting.MeetingStatus);
            
            instanceUnloaded.WaitOne();
        }
        public static void OnWorkflowCompleted(WorkflowApplicationCompletedEventArgs e)
        { 
        }

        public static void OnIdle(WorkflowApplicationIdleEventArgs e)
        { 
        }

        public static PersistableIdleAction OnIdleAndPersist(WorkflowApplicationIdleEventArgs e)
        {
            return PersistableIdleAction.Persist;
        }

    }
}
