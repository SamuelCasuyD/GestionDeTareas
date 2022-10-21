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
   public class k2blistprograms : GXProcedure
   {
      public k2blistprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2blistprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "TABLEROS_WEB") ;
         initialize();
         executePrivate();
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      public GXBaseCollection<SdtK2BProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV8ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames )
      {
         k2blistprograms objk2blistprograms;
         objk2blistprograms = new k2blistprograms();
         objk2blistprograms.AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "TABLEROS_WEB") ;
         objk2blistprograms.context.SetSubmitInitialConfig(context);
         objk2blistprograms.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2blistprograms);
         aP0_ProgramNames=this.AV8ProgramNames;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2blistprograms)stateInfo).executePrivate();
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
         new k2bisauthorizedactivitylist(context ).execute( ref  AV13ActivityList) ;
         AV8ProgramNames = new GXBaseCollection<SdtK2BProgramNames_ProgramName>( context, "ProgramName", "TABLEROS_WEB");
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         if ( AV15SecurityIndex > 0 )
         {
            if ( ((SdtK2BActivityList_K2BActivityListItem)AV13ActivityList.Item(AV15SecurityIndex)).gxTpr_Isauthorized )
            {
               AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
               AV9ProgramName.gxTpr_Name = AV10name;
               AV9ProgramName.gxTpr_Description = AV11description;
               AV9ProgramName.gxTpr_Link = AV12link;
               AV8ProgramNames.Add(AV9ProgramName, 0);
            }
         }
         else
         {
            AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
            AV9ProgramName.gxTpr_Name = AV10name;
            AV8ProgramNames.Add(AV9ProgramName, 0);
         }
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
         AV13ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "TABLEROS_WEB");
         AV9ProgramName = new SdtK2BProgramNames_ProgramName(context);
         AV10name = "";
         AV11description = "";
         AV12link = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15SecurityIndex ;
      private String AV10name ;
      private String AV11description ;
      private String AV12link ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> aP0_ProgramNames ;
      private GXBaseCollection<SdtK2BProgramNames_ProgramName> AV8ProgramNames ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV13ActivityList ;
      private SdtK2BProgramNames_ProgramName AV9ProgramName ;
   }

}
