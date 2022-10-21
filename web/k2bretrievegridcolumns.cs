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
   public class k2bretrievegridcolumns : GXProcedure
   {
      public k2bretrievegridcolumns( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bretrievegridcolumns( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_GridName ,
                           out GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV9GridName = aP1_GridName;
         this.AV8GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB") ;
         initialize();
         executePrivate();
         aP2_GridColumns=this.AV8GridColumns;
      }

      public GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> executeUdp( String aP0_ProgramName ,
                                                                                String aP1_GridName )
      {
         execute(aP0_ProgramName, aP1_GridName, out aP2_GridColumns);
         return AV8GridColumns ;
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_GridName ,
                                 out GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns )
      {
         k2bretrievegridcolumns objk2bretrievegridcolumns;
         objk2bretrievegridcolumns = new k2bretrievegridcolumns();
         objk2bretrievegridcolumns.AV10ProgramName = aP0_ProgramName;
         objk2bretrievegridcolumns.AV9GridName = aP1_GridName;
         objk2bretrievegridcolumns.AV8GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB") ;
         objk2bretrievegridcolumns.context.SetSubmitInitialConfig(context);
         objk2bretrievegridcolumns.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bretrievegridcolumns);
         aP2_GridColumns=this.AV8GridColumns;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bretrievegridcolumns)stateInfo).executePrivate();
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
      private String AV9GridName ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV8GridColumns ;
   }

}
