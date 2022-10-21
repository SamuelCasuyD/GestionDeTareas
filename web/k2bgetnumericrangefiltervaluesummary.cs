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
   public class k2bgetnumericrangefiltervaluesummary : GXProcedure
   {
      public k2bgetnumericrangefiltervaluesummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetnumericrangefiltervaluesummary( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_SemanticNumericRange ,
                           String aP1_From ,
                           String aP2_To ,
                           out String aP3_Result )
      {
         this.AV11SemanticNumericRange = aP0_SemanticNumericRange;
         this.AV8From = aP1_From;
         this.AV9To = aP2_To;
         this.AV10Result = "" ;
         initialize();
         executePrivate();
         aP3_Result=this.AV10Result;
      }

      public String executeUdp( String aP0_SemanticNumericRange ,
                                String aP1_From ,
                                String aP2_To )
      {
         execute(aP0_SemanticNumericRange, aP1_From, aP2_To, out aP3_Result);
         return AV10Result ;
      }

      public void executeSubmit( String aP0_SemanticNumericRange ,
                                 String aP1_From ,
                                 String aP2_To ,
                                 out String aP3_Result )
      {
         k2bgetnumericrangefiltervaluesummary objk2bgetnumericrangefiltervaluesummary;
         objk2bgetnumericrangefiltervaluesummary = new k2bgetnumericrangefiltervaluesummary();
         objk2bgetnumericrangefiltervaluesummary.AV11SemanticNumericRange = aP0_SemanticNumericRange;
         objk2bgetnumericrangefiltervaluesummary.AV8From = aP1_From;
         objk2bgetnumericrangefiltervaluesummary.AV9To = aP2_To;
         objk2bgetnumericrangefiltervaluesummary.AV10Result = "" ;
         objk2bgetnumericrangefiltervaluesummary.context.SetSubmitInitialConfig(context);
         objk2bgetnumericrangefiltervaluesummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetnumericrangefiltervaluesummary);
         aP3_Result=this.AV10Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetnumericrangefiltervaluesummary)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV11SemanticNumericRange, "K2BToolsNumericRangeManual") == 0 )
         {
            AV10Result = StringUtil.Trim( AV8From) + " - " + StringUtil.Trim( AV9To);
         }
         else
         {
            AV10Result = AV11SemanticNumericRange;
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

      private String AV11SemanticNumericRange ;
      private String AV8From ;
      private String AV9To ;
      private String AV10Result ;
      private String aP3_Result ;
   }

}
