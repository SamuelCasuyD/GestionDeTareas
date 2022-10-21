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
   public class k2bgetstandardfiltervaluesummary : GXProcedure
   {
      public k2bgetstandardfiltervaluesummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetstandardfiltervaluesummary( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_Value ,
                           out String aP1_Summary )
      {
         this.AV9Value = aP0_Value;
         this.AV8Summary = "" ;
         initialize();
         executePrivate();
         aP1_Summary=this.AV8Summary;
      }

      public String executeUdp( String aP0_Value )
      {
         execute(aP0_Value, out aP1_Summary);
         return AV8Summary ;
      }

      public void executeSubmit( String aP0_Value ,
                                 out String aP1_Summary )
      {
         k2bgetstandardfiltervaluesummary objk2bgetstandardfiltervaluesummary;
         objk2bgetstandardfiltervaluesummary = new k2bgetstandardfiltervaluesummary();
         objk2bgetstandardfiltervaluesummary.AV9Value = aP0_Value;
         objk2bgetstandardfiltervaluesummary.AV8Summary = "" ;
         objk2bgetstandardfiltervaluesummary.context.SetSubmitInitialConfig(context);
         objk2bgetstandardfiltervaluesummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetstandardfiltervaluesummary);
         aP1_Summary=this.AV8Summary;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetstandardfiltervaluesummary)stateInfo).executePrivate();
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
         if ( StringUtil.Len( AV9Value) > 30 )
         {
            AV8Summary = StringUtil.Substring( AV9Value, 1, 30) + "...";
         }
         else
         {
            AV8Summary = AV9Value;
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

      private String AV9Value ;
      private String AV8Summary ;
      private String aP1_Summary ;
   }

}
