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
   public class k2bpersistgridcolumns : GXProcedure
   {
      public k2bpersistgridcolumns( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bpersistgridcolumns( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_GridName ,
                           GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridState )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV9GridState = aP2_GridState;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_GridName ,
                                 GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridState )
      {
         k2bpersistgridcolumns objk2bpersistgridcolumns;
         objk2bpersistgridcolumns = new k2bpersistgridcolumns();
         objk2bpersistgridcolumns.AV10ProgramName = aP0_ProgramName;
         objk2bpersistgridcolumns.AV8GridName = aP1_GridName;
         objk2bpersistgridcolumns.AV9GridState = aP2_GridState;
         objk2bpersistgridcolumns.context.SetSubmitInitialConfig(context);
         objk2bpersistgridcolumns.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bpersistgridcolumns);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bpersistgridcolumns)stateInfo).executePrivate();
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

      private String AV10ProgramName ;
      private String AV8GridName ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV9GridState ;
   }

}
