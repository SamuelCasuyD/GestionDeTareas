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
   public class k2bgetdatetimerangefiltervaluesummary : GXProcedure
   {
      public k2bgetdatetimerangefiltervaluesummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetdatetimerangefiltervaluesummary( IGxContext context )
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
         k2bgetdatetimerangefiltervaluesummary objk2bgetdatetimerangefiltervaluesummary;
         objk2bgetdatetimerangefiltervaluesummary = new k2bgetdatetimerangefiltervaluesummary();
         objk2bgetdatetimerangefiltervaluesummary.AV11SemanticDateRange = aP0_SemanticDateRange;
         objk2bgetdatetimerangefiltervaluesummary.AV8DateFrom = aP1_DateFrom;
         objk2bgetdatetimerangefiltervaluesummary.AV9DateTo = aP2_DateTo;
         objk2bgetdatetimerangefiltervaluesummary.AV10Result = "" ;
         objk2bgetdatetimerangefiltervaluesummary.context.SetSubmitInitialConfig(context);
         objk2bgetdatetimerangefiltervaluesummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetdatetimerangefiltervaluesummary);
         aP3_Result=this.AV10Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetdatetimerangefiltervaluesummary)stateInfo).executePrivate();
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
            AV10Result = context.localUtil.TToC( AV8DateFrom, 8, 5, 1, 2, "/", ":", " ") + " - " + context.localUtil.TToC( AV9DateTo, 8, 5, 1, 2, "/", ":", " ");
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
