using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bisauthorizedactivityname : GXProcedure
   {
      public k2bisauthorizedactivityname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bisauthorizedactivityname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_EntityName ,
                           String aP1_TransactionName ,
                           String aP2_StandardActivityType ,
                           String aP3_UserActivityType ,
                           String aP4_ProgramName ,
                           out bool aP5_IsAuthorized )
      {
         this.AV12EntityName = aP0_EntityName;
         this.AV13TransactionName = aP1_TransactionName;
         this.AV14StandardActivityType = aP2_StandardActivityType;
         this.AV15UserActivityType = aP3_UserActivityType;
         this.AV11ProgramName = aP4_ProgramName;
         this.AV10IsAuthorized = false ;
         initialize();
         executePrivate();
         aP5_IsAuthorized=this.AV10IsAuthorized;
      }

      public bool executeUdp( String aP0_EntityName ,
                              String aP1_TransactionName ,
                              String aP2_StandardActivityType ,
                              String aP3_UserActivityType ,
                              String aP4_ProgramName )
      {
         execute(aP0_EntityName, aP1_TransactionName, aP2_StandardActivityType, aP3_UserActivityType, aP4_ProgramName, out aP5_IsAuthorized);
         return AV10IsAuthorized ;
      }

      public void executeSubmit( String aP0_EntityName ,
                                 String aP1_TransactionName ,
                                 String aP2_StandardActivityType ,
                                 String aP3_UserActivityType ,
                                 String aP4_ProgramName ,
                                 out bool aP5_IsAuthorized )
      {
         k2bisauthorizedactivityname objk2bisauthorizedactivityname;
         objk2bisauthorizedactivityname = new k2bisauthorizedactivityname();
         objk2bisauthorizedactivityname.AV12EntityName = aP0_EntityName;
         objk2bisauthorizedactivityname.AV13TransactionName = aP1_TransactionName;
         objk2bisauthorizedactivityname.AV14StandardActivityType = aP2_StandardActivityType;
         objk2bisauthorizedactivityname.AV15UserActivityType = aP3_UserActivityType;
         objk2bisauthorizedactivityname.AV11ProgramName = aP4_ProgramName;
         objk2bisauthorizedactivityname.AV10IsAuthorized = false ;
         objk2bisauthorizedactivityname.context.SetSubmitInitialConfig(context);
         objk2bisauthorizedactivityname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bisauthorizedactivityname);
         aP5_IsAuthorized=this.AV10IsAuthorized;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bisauthorizedactivityname)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8activity.gxTpr_Entityname = AV12EntityName;
         AV8activity.gxTpr_Pgmname = AV11ProgramName;
         AV8activity.gxTpr_Standardactivitytype = AV14StandardActivityType;
         AV8activity.gxTpr_Transactionname = AV13TransactionName;
         AV8activity.gxTpr_Useractivitytype = AV15UserActivityType;
         GXt_boolean1 = AV10IsAuthorized;
         new k2bisauthorizedactivity(context ).execute(  AV8activity, out  GXt_boolean1) ;
         AV10IsAuthorized = GXt_boolean1;
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8activity = new SdtK2BActivity(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV14StandardActivityType ;
      private bool AV10IsAuthorized ;
      private bool GXt_boolean1 ;
      private String AV12EntityName ;
      private String AV13TransactionName ;
      private String AV15UserActivityType ;
      private String AV11ProgramName ;
      private bool aP5_IsAuthorized ;
      private SdtK2BActivity AV8activity ;
   }

}
