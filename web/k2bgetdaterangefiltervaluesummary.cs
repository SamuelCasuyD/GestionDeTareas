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
   public class k2bgetdaterangefiltervaluesummary : GXProcedure
   {
      public k2bgetdaterangefiltervaluesummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetdaterangefiltervaluesummary( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_SemanticDateRange ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo ,
                           out String aP3_Result )
      {
         this.AV11SemanticDateRange = aP0_SemanticDateRange;
         this.AV8DateFrom = aP1_DateFrom;
         this.AV9DateTo = aP2_DateTo;
         this.AV10Result = "" ;
         initialize();
         executePrivate();
         aP3_Result=this.AV10Result;
      }

      public String executeUdp( String aP0_SemanticDateRange ,
                                DateTime aP1_DateFrom ,
                                DateTime aP2_DateTo )
      {
         execute(aP0_SemanticDateRange, aP1_DateFrom, aP2_DateTo, out aP3_Result);
         return AV10Result ;
      }

      public void executeSubmit( String aP0_SemanticDateRange ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo ,
                                 out String aP3_Result )
      {
         k2bgetdaterangefiltervaluesummary objk2bgetdaterangefiltervaluesummary;
         objk2bgetdaterangefiltervaluesummary = new k2bgetdaterangefiltervaluesummary();
         objk2bgetdaterangefiltervaluesummary.AV11SemanticDateRange = aP0_SemanticDateRange;
         objk2bgetdaterangefiltervaluesummary.AV8DateFrom = aP1_DateFrom;
         objk2bgetdaterangefiltervaluesummary.AV9DateTo = aP2_DateTo;
         objk2bgetdaterangefiltervaluesummary.AV10Result = "" ;
         objk2bgetdaterangefiltervaluesummary.context.SetSubmitInitialConfig(context);
         objk2bgetdaterangefiltervaluesummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetdaterangefiltervaluesummary);
         aP3_Result=this.AV10Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetdaterangefiltervaluesummary)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV11SemanticDateRange, "K2BToolsDateRangeManual") == 0 )
         {
            AV10Result = context.localUtil.DToC( AV8DateFrom, 1, "/") + " - " + context.localUtil.DToC( AV9DateTo, 1, "/");
         }
         else
         {
            AV10Result = AV11SemanticDateRange;
         }
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV11SemanticDateRange ;
      private DateTime AV8DateFrom ;
      private DateTime AV9DateTo ;
      private String AV10Result ;
      private String aP3_Result ;
   }

}
